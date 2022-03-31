<template>
  <q-page id="pagina">
    <q-card class="area">
      <div class="row">
        <h5 class="titulo text- q-ma-md"> Professores </h5>
      </div>
      <q-table
      :loading="loading"
      title="orgaos"
      separator="cell"
      :dense="$q.screen.lt.md"
      :rows="dados" 
      :columns="columns" 
      row-key="id"
      :filter="filter"
      :visible-columns="visibleColumns"
      no-data-label="Não encontrei nada para você"
      no-results-label="Nenhum item corresponde a busca">>

      <template v-slot:header="props">
          <q-tr :props="props">
            <q-th
              v-for="col in props.cols"
              :key="col.name"
              :props="props"
              class="text-uppercase bg-grey-8 text-white border-white"
            >
              {{ col.label }}
            </q-th>
          </q-tr>
        </template>
        
          <template v-slot:body-cell-ativo="props">
          <q-td :props="props" >
            {{ props.row.arteMarcial.nome }}
          </q-td>
        </template>

        <template v-slot:top="props">
          <q-input dense debounce="300" v-model="filter" placeholder="Busca" class="q-mr-lg">
            <template v-slot:append>
              <q-icon name="search" />
            </template>
          </q-input>
          <div v-if="$q.screen.gt.xs" class="col">
            <q-toggle v-model="visibleColumns" val="telefone" label="telefone" />
            <q-toggle v-model="visibleColumns" val="ativo" label="Arte Marcial" />
          </div>
          <q-select
            v-else
            v-model="visibleColumns"
            multiple
            borderless
            dense
            options-dense
            display-value="Colunas visiveis"
            emit-value
            map-options
            :options="colunas"
            style="min-width: 100px"
          />

          <q-btn
            flat round dense
            :icon="props.inFullscreen ? 'fullscreen_exit' : 'fullscreen'"
            @click="props.toggleFullscreen"
            class="q-ml-md"
          />
        </template>
      </q-table>
    </q-card>
  </q-page>
</template>

<script>

import { useQuasar } from 'quasar'

import api from 'src/boot/axios.js'

const $q = useQuasar()

export default {
  setup () {
    const $q = useQuasar()

    return {
      showNotif(mensagem, cor) {
        $q.notify({
          position: 'top',
          message: mensagem,
          color: cor
        })
      }
    }
  },
  data() {
    return {
      confirmarExclusao: false,
      excluir: '',
      vizualizar: false,
      desativar: '',
      ativar: '',
      idStatus: '',
      nomeStatus: '',
      loading: true,
      confirmDesativar: false,
      confirmAtivar: false,
      text: "",
      filter: '',
      colunas: ['telefone', 'arteMarcialId', 'ativo'],
      columns: [
        {name: 'nome', required: true, align: 'left', label: 'Nome', field: 'nome', sortable: true},
        {name: 'telefone', align: 'left', label: 'Telefone', field: 'telefone', sortable: true},
        {name: 'ativo', align: 'center', label: 'Arte Marcial', align: 'center', field: 'ativo', sortable: true}
      ],
      dados: [],
      visibleColumns: (['nome', 'telefone', 'arteMarcialId', 'ativo' ]),
      professor: {
                nome: '',
                cpf: '',
                telefone: '',
                dataInicio: '',
                dataFim: '',
                ativo: '',
                arteMarcial: {
                  nome: ''
                }
            }
    }
  },
  methods: {
    getProfessores() {
      api.getProfessoresAtivo().then(response => {
              if(response.status == 200) {  
                
                  this.dados = response.data;
                  this.loading = false;    
                }
        });
    },
    detalhes(id) {
      this.vizualizar = true;
      api.getProfessorById(id).then(response => {
        if(response.status == 200) { 
          console.log(response)
          this.professor = response.data
          this.professor.dataInicio = response.data.dataInicio.split('T')[0]
          this.professor.dataFim = response.data.dataFim.split('T')[0]
        }
      });
    }
  },
  mounted() {
    this.getProfessores()
  }
}
</script>

<style scoped>

  .area {
    border-radius: 10px;
  }

  #pagina {
    padding: 20px;
  }

  @media screen and (max-width: 770px) {
    #pagina {
      padding: 5px;
    }
  }

  .titulo {
    margin-left: 3%;
  }

  .q-table--grid.fullscreen {
    background-color: #FFF;
  }

</style>
