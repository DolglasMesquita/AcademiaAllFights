<template>
  <q-page id="pagina">
    <q-card class="area">
      <div class="row">
        <h5 class="titulo text- q-ma-md"> Artes Marciais </h5>
          <q-btn to="/ArteMarcial/adicionar" color="primary" size="sm" class="q-ma-md" icon-right="add"> Adicionar  </q-btn>
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

        <template v-slot:body-cell-action="props">
          <q-td :props="props">
              <q-btn :to="{path: '/artemarcial/editar/' + props.row.id}" icon="create" color="secondary" size="sm" flat dense round/>
              <q-btn icon="delete" color="negative" size="sm" flat dense round @click="confirmarExclusao = true;nomeStatus = props.row.nome;idStatus = props.row.id"/>
              <q-dialog v-model="confirmarExclusao" persistent>
                <q-card>
                  <q-card-section class="row items-center bg-negative">
                    <span class="q-ma-lg text-white text-center"> 
                      Deseja remover permanentemente o ArteMarcial? <br>
                      Todos os professores que forem vinculados a ela também serão removidos 
                      <div class="text-center	text-bold	q-pt-md"> 
                      <strong> {{ nomeStatus }} </strong>
                    </div>
                    </span>
                  </q-card-section>

                <q-card-actions align="right">
                  <q-btn flat label="Cancelar" color="primary" v-close-popup/>
                  <q-btn flat icon-right="delete_forever" label="Remover" color="negative" @click="deletarArteMarcial()" v-close-popup/>
                </q-card-actions>
              </q-card>
            </q-dialog>
          </q-td>
        </template>

          <template v-slot:body-cell-ativo="props">
          <q-td :props="props" >
            <q-icon v-if="props.row.ativo" name="toggle_on" color="primary" size="md" @click="confirmDesativar = true;nomeStatus = props.row.nome;idStatus = props.row"/>
            <q-icon v-if="!props.row.ativo" name="toggle_off" color="negative" size="md" @click="confirmAtivar = true;nomeStatus = props.row.nome;idStatus = props.row"/>
            <q-dialog v-model="confirmDesativar" persistent>
              <q-card>
                <q-card-section class="row items-center">
                  <span class="q-ma-lg"> Deseja desativar ?
                    <div class="text-center	text-bold	q-pt-md"> 
                  {{ nomeStatus }}
                  </div>
                  </span>
                </q-card-section>

                <q-card-actions align="right">
                  <q-btn flat label="Cancelar" color="primary" v-close-popup />
                  <q-btn flat icon-right="toggle_off" label="Desativar" color="negative" @click="desativarArteMarcial()" v-close-popup />
                </q-card-actions>
              </q-card>
            </q-dialog>

            <q-dialog v-model="confirmAtivar" persistent>
              <q-card>
                <q-card-section class="row items-center">
                  <span class="q-ma-lg"> Deseja ativar ?
                    <div class="text-center	text-bold	q-pt-md"> 
                      {{ nomeStatus }}
                    </div>
                  </span>
                </q-card-section>

                <q-card-actions align="right">
                  <q-btn flat label="Cancelar" color="primary" v-close-popup/>
                  <q-btn flat icon-right="toggle_on" label="Ativar" color="positive" @click="ativarArteMarcial()" v-close-popup/>
                </q-card-actions>
              </q-card>
            </q-dialog>
          </q-td>
        </template>

        <template v-slot:top="props">
          <q-input dense debounce="300" v-model="filter" placeholder="Busca" class="q-mr-lg">
            <template v-slot:append>
              <q-icon name="search" />
            </template>
          </q-input>
          <div v-if="$q.screen.gt.xs" class="col">
            <q-toggle v-model="visibleColumns" val="action" label="ações" />
            <q-toggle v-model="visibleColumns" val="ativo" label="status" />
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
      colunas: ['action', 'ativo'],
      columns: [
        {name: 'action', label: '', align: 'center'},
        {name: 'nome', required: true, align: 'left', label: 'Nome', field: 'nome', sortable: true},
        {name: 'ativo', align: 'center', label: 'Status', align: 'center', field: 'ativo', sortable: true}
      ],
      dados: [],
      visibleColumns: ([ 'action', 'nome', 'ativo' ]),
      arteMarcial: {
        nome: '',
        ativo: ''
      },
      arteMarcialAtivarDesativar: {
        id: '',
        nome: '',
        ativo: ''
      }
    }
  },
  methods: {
    getArtesMarciais() {
      api.getArtesMarciais().then(response => {
              if(response.status == 200) {  
                  this.dados = response.data;
                  this.loading = false;    
                }
        });
    },
    ativarArteMarcial() {
      this.arteMarcialAtivarDesativar.id = this.idStatus.id;
      this.arteMarcialAtivarDesativar.nome = this.idStatus.nome;
      this.arteMarcialAtivarDesativar.ativo = true,

      api.desativarAtivarArteMarcial(this.arteMarcialAtivarDesativar.id, this.arteMarcialAtivarDesativar).then(r => {
        this.showNotif('A arte marcial foi ativada', 'positive');
        this.getArtesMarciais();
      });
    },
    desativarArteMarcial() {
      this.arteMarcialAtivarDesativar.id = this.idStatus.id;
      this.arteMarcialAtivarDesativar.nome = this.idStatus.nome;
      this.arteMarcialAtivarDesativar.ativo = false,

      api.desativarAtivarArteMarcial(this.arteMarcialAtivarDesativar.id, this.arteMarcialAtivarDesativar).then(r => {
        this.showNotif('A arte marcial foi desativada', 'positive');
        this.getArtesMarciais();
      });
    },
    detalhes(id) {
      this.vizualizar = true;
      api.getArtesMarciaisById(id).then(response => {
        if(response.status == 200) { 
          console.log(response)
          this.ArteMarcial = response.data
        }
      });
    },
    deletarArteMarcial() {
      api.removerArteMarcial(this.idStatus).then(response => {
        if(response.status == 200) {
          this.showNotif('O ArteMarcial foi removida com sucesso', 'positive');
          this.getArtesMarciais();
        }
      })
    }
  },
  mounted() {
    this.getArtesMarciais()
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
