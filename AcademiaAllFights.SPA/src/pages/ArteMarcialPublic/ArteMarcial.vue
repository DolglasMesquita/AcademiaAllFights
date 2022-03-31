<template>
  <q-page id="pagina">
    <q-card class="area">
      <div class="row">
        <h5 class="titulo text- q-ma-md"> Artes Marciais </h5>
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
      colunas: ['action'],
      columns: [
        {name: 'nome', required: true, align: 'left', label: 'Nome', field: 'nome', sortable: true},
      ],
      dados: [],
      visibleColumns: ([ 'nome']),
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
      api.getArtesMarciaisAtivo().then(response => {
              if(response.status == 200) {  
                  this.dados = response.data;
                  this.loading = false;    
                }
        });
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
