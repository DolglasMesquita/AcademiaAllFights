<template>
  <q-page id="pagina">
    <q-card class="area">
      <div class="row">
        <h5 class="titulo text- q-ma-md"> Alunos </h5>
          <q-btn to="/aluno/adicionar" color="primary" size="sm" class="q-ma-md" icon-right="add"> Adicionar  </q-btn>
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
      no-results-label="Nenhum item corresponde a busca">

        <template v-slot:body-cell-action="props">
          <q-td :props="props">
            <q-btn icon="search" color="primary" size="sm" flat dense round @click="detalhes(props.row.id)"/>
            <q-dialog v-model="vizualizar">
                <q-card>
                  <q-card-section>
                    <div class="text-h5"> {{ aluno.nome }} </div>
                  </q-card-section>

                  <q-card-section class="q-pt-none">
                    <q-input readonly v-model="aluno.cpf" label="Cpf" mask="###.###.###-##" />
                    <q-input readonly v-model="aluno.telefone" label="Telefone" mask="(##)#####-####" />
                    <q-input readonly type="date" v-model="aluno.dataInicio" label="Data Inicio" />
                    <q-input v-if="!aluno.ativo" readonly type="date" v-model="aluno.dataFim" label="Data Fim" />
                    <br>
                    <strong> Artes Marciais: </strong>
                    <q-list separator>
                      <q-item v-ripple v-for="arte in aluno.alunosArtesMarciais" :key="arte.arteMarcial.id">
                          <q-item-section>
                              <q-item-label> 
                                  <p> {{arte.arteMarcial.nome}} </p>
                                  <p v-if="arte.arteMarcial == null"> {{arte.arteMarcial.nome}} </p>
                              </q-item-label>
                          </q-item-section>
                      </q-item>
                    </q-list>
                    <br/>
                    <p v-if="aluno.ativo"> <strong> Status: </strong> Ativo </p>
                    <p v-if="!aluno.ativo"> <strong> Status: </strong> Inativo </p>
                  </q-card-section>

                  <q-card-actions align="right">
                    <q-btn flat label="voltar" color="primary" v-close-popup />
                  </q-card-actions>
                </q-card>
              </q-dialog>

              <q-btn :to="{path: '/aluno/editar/' + props.row.id}" icon="create" color="secondary" size="sm" flat dense round/>
              <q-btn icon="delete" color="negative" size="sm" flat dense round @click="confirmarExclusao = true;nomeStatus = props.row.nome;idStatus = props.row.id"/>
              <q-dialog v-model="confirmarExclusao" persistent>
              <q-card>
                <q-card-section class="row items-center bg-negative">
                  <span class="q-ma-lg text-white"> 
                    Deseja remover permanentemente o professor? 
                    <div class="text-center	text-bold	q-pt-md"> 
                    <strong> {{ nomeStatus }} </strong>
                  </div>
                  </span>
                </q-card-section>

                <q-card-actions align="right">
                  <q-btn flat label="Cancelar" color="primary" v-close-popup/>
                  <q-btn flat icon-right="delete_forever" label="Remover" color="negative" @click="deletarAluno()" v-close-popup/>
                </q-card-actions>
              </q-card>
            </q-dialog>
          </q-td>
        </template>

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
            <q-icon v-if="props.row.ativo" name="toggle_on" color="primary" size="md" @click="confirmDesativar = true;nomeStatus = props.row.nome;idStatus = props.row.id"/>
            <q-icon v-if="!props.row.ativo" name="toggle_off" color="negative" size="md" @click="confirmAtivar = true;nomeStatus = props.row.nome;idStatus = props.row.id"/>
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
                  <q-btn flat icon-right="toggle_off" label="Desativar" color="negative" @click="desativarAluno()" v-close-popup />
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
                  <q-btn flat icon-right="toggle_on" label="Ativar" color="positive" @click="ativarAluno()" v-close-popup/>
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
            <q-toggle v-model="visibleColumns" val="cpf" label="cpf" />
            <q-toggle v-model="visibleColumns" val="telefone" label="telefone" />
            <q-toggle v-model="visibleColumns" val="idade" label="idade" />
            <q-toggle v-model="visibleColumns" val="ativo" label="ativo" />
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
      showNotif (mensagem) {
        $q.notify({
          position: 'top',
          message: mensagem,
          color: 'positive'
        })
      }
    }
  },
  data() {
    return {
      confirmarExclusao: false,
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
      colunas: [ 'action', 'cpf', 'telefone', 'idade', 'ativo'],
      columns: [
        {name: 'action', label: '', align: 'center'},
        {name: 'id', align: 'left', label: 'Id', field: 'id', sortable: true},
        {name: 'nome', required: true, align: 'left', label: 'Nome', field: 'nome', sortable: true},
        {name: 'cpf', align: 'left', label: 'Cpf', field: 'cpf', sortable: true},
        {name: 'telefone', align: 'left', label: 'Telefone', field: 'telefone', sortable: true},
        {name: 'idade', align: 'center', label: 'Idade', align: 'center', field: 'idade', sortable: true},
        {name: 'ativo', align: 'center', label: 'Ativo', align: 'center', field: 'ativo', sortable: true}
      ],
      dados: [],
      visibleColumns: ([ 'action', 'nome', 'cpf', 'telefone', 'idade', 'ativo' ]),
      aluno: {
          nome: '',
          cpf: '',
          telefone: '',
          dataNascimento: '',
          dataInicio: '',
          dataFim: '',
          ativo: '',
          alunosArtesMarciais: [{
              alunoId: '',
              arteMarcialId: '',
              arteMarcial: {
                  id: '', 
                  nome: '', 
                  ativo: ''
              }
          }]
      }
    }
  },
  methods: {
    detalhes(id) {
      this.vizualizar = true;
      api.getAlunoById(id).then(response => {
        if(response.status == 200) { 
            this.aluno = response.data
            this.aluno.dataInicio = response.data.dataInicio.split('T')[0]
            if(response.data.dataFim != null) {
                    this.aluno.dataFim = response.data.dataFim.split('T')[0]
                  }
          }
      });

    },
    getalunos() {
      api.getAlunos().then(response => {
              if(response.status == 200) {  
                  this.dados = response.data
                  this.loading = false;         
                }
        });
    },
    ativarAluno() {
      api.ativarAluno(this.idStatus).then(r => {
        this.showNotif(r.data);
        this.getalunos();
      });
    },
    desativarAluno() {
      api.desativarAluno(this.idStatus).then(r => {
        this.showNotif(r.data);
        this.getalunos();
      });
    },
    deletarAluno() {
      api.removerAluno(this.idStatus).then(response => {
        if(response.status == 200) {
          this.showNotif('O aluno foi removido', 'negative');
          this.getalunos();
        }
      })
    }
  },
  mounted() {
    this.getalunos()
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
