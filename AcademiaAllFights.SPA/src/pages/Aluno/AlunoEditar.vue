<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Editar Aluno </p>

        <q-form @submit.prevent="editarAluno()">
            <div class="q-gutter-md">
                <q-input filled v-model="aluno.nome" label="Nome" />
                <q-input filled v-model="aluno.cpf" label="Cpf" mask="###.###.###-##"/>
                <q-input filled v-model="aluno.telefone" label="Telefone" mask="(##)#####-####"/>
                <q-input filled type="date" v-model="aluno.dataNascimento" label="Data Nascimento" />
                <q-input filled type="date" v-model="aluno.dataInicio" label="Data Início" />
                <q-input v-if="!aluno.ativo" filled type="date" v-model="aluno.dataFim" label="Data Fim" />

                <hr/>

                <p class="text-h5" > Artes marciais: <q-btn size="sm" dense color="primary" icon="add" @click="popupAdd()"/> </p>
                
                <q-list bordered separator>
                    <q-item clickable v-ripple v-for="arte in alunoArteMarcial" :key="arte.id">
                        <q-item-section>
                                <q-item-label> 
                                    {{ arte.arteMarcial.nome }}
                                <q-item-label v-if="!arte.arteMarcial.ativo" caption>inativo</q-item-label>
                            </q-item-label>
                        </q-item-section>
                        <q-item-section top side >
                            <q-btn class="gt-xs" size="12px" flat dense round icon="remove_circle_outline" color="negative" @click="confirmarRemoverArteMarcial(arte)"/>
                        </q-item-section>    
                    </q-item>
                </q-list>

                <q-dialog v-model="removerArteMarcial">
                    <q-card>
                        <q-card-section class="row items-center">
                        <span class="q-ma-lg"> Deseja remover a arte marcial ?
                            <div class="text-center	text-bold q-pt-md"> 
                                {{ arteMarcialRemover.nome }}
                            </div>
                        </span>
                        </q-card-section>

                        <q-card-actions align="right">
                        <q-btn flat label="Cancelar" color="primary" v-close-popup />
                        <q-btn flat icon-right="delete" label="remover" color="negative" @click="removerArteMarcialAluno()" v-close-popup />
                        </q-card-actions>
                    </q-card>
                    </q-dialog>
                
                <div>
                    <q-btn color="primary" type="submit"> Salvar alterações </q-btn>
                    <q-btn  to="/aluno" color="secondary" icon-right="arrow_back" class="q-ml-sm" />
                </div>
            </div>
        </q-form>

    </q-card>
  </q-page>
</template>

<script>

import { useQuasar } from 'quasar'
import api from 'src/boot/axios.js'

export default {
    setup () {
        const $q = useQuasar()

        return {
            addArteMarcial(busca) {
                $q.dialog({
                    title: 'Adicionar',
                    message: 'Selecione uma arte marcial para adicionar',
                    options: {
                    type: 'radio',
                    model: '',
                    isValid: (model) => model != '', 
                    items: busca,
                    },
                    cancel: true,
                    persistent: true
                }).onOk(data => {
                    this.salvarArteMarcial(data);
                })
            },
            sucesso() {
                $q.dialog({
                    message: 'Aluno editado com sucesso!'
                }).onOk(() => {
                    window.location.href = "/aluno"
                })
            },
             mostrarNotificacao(mensagem, cor) {
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
            existe: '',
            removerArteMarcial: false,
            teste: '',
            aluno: {
                id: '',
                nome: '',
                cpf: '',
                telefone: '',
                dataNascimento: '',
                dataInicio: '',
                dataFim: '',
                ativo: '',
            },
            alunoArteMarcial: [],
            arteMarcialRemover: {
                nome: '',
                arteMarcialId: '',
                alunoId: ''
            },
            arteMarcialSalvar: {
                arteMarcialId: '',
                alunoId: ''
            },
            busca: []
        }
    },
    methods: {
        popupAdd() {
            this.addArteMarcial(this.busca);
        },
        salvarArteMarcial(id) {
            this.arteMarcialSalvar.arteMarcialId = id;
            this.arteMarcialSalvar.alunoId = this.aluno.id;

            this.alunoArteMarcial.forEach((valor) => {
                if(id == valor.arteMarcialId){
                    this.existe = true    
                }
            });

            if(this.existe) {
                this.mostrarNotificacao('Arte marcial já cadastrada', 'warning')
                this.existe = false
            } else {
                api.salvarAlunoArtesMarciais(this.arteMarcialSalvar).then(response => {
                    if(response.status == 201) {
                        this.mostrarNotificacao('Arte marcial cadastrada com sucesso', 'positive');
                        this.listaArtesMarciaisAluno();
                        this.arteMarcialSalvar = {};
                    }
                })
            }
        },
        localizarAluno() {
            api.getAlunoById(this.$route.params.id).then(response => {
              if(response.status == 200) { 
                  this.aluno = response.data;    
                  this.aluno.dataNascimento = response.data.dataNascimento.split('T')[0]
                  this.aluno.dataInicio = response.data.dataInicio.split('T')[0]
                  if(response.data.dataFim != null) {
                    this.aluno.dataFim = response.data.dataFim.split('T')[0]
                  }
                }
            });
        },
        listaArtesMarciaisAluno() {
            api.getAlunoArtesMarciais(this.$route.params.id).then(request => {
              if(request.status == 200) { 
                  this.alunoArteMarcial = request.data
                }
            });
        },
        carregarArtesMarciais() {
            api.getArtesMarciais().then(request => {
              if(request.status == 200) { 
                    request.data.forEach((valor, i) => {
                        var obj = {
                            value: 0, 
                            label: 0
                        }

                        obj.value = valor.id;
                        obj.label = valor.nome;
                        
                        if(valor.ativo) {
                            this.busca[i] = obj; 
                        }
                            
                    });
                }
            }
        )},
        editarAluno() {
            this.aluno.dataNascimento += 'T00:00:00';
            this.aluno.dataInicio += 'T00:00:00';
            if(this.aluno.dataFim != null) {
                this.aluno.dataFim += 'T00:00:00';
            }

            api.updateAluno(this.aluno, this.aluno.id).then(response => {
                if(response.status == 200) {
                    this.sucesso();
                }
            }).catch(e => {
                    console.log(e)
                   this.mostrarNotificacao('Erro ao editar aluno, confira os dados e tente novamente', 'negative')
                });
            
        },
        confirmarRemoverArteMarcial(obj) {
            this.arteMarcialRemover.alunoId = obj.alunoId;
            this.arteMarcialRemover.arteMarcialId = obj.arteMarcialId;
            this.arteMarcialRemover.nome = obj.arteMarcial.nome;
            this.removerArteMarcial = true;
        },
        removerArteMarcialAluno() {
            api.removerAlunoArtesMarciais(this.arteMarcialRemover.alunoId, this.arteMarcialRemover.arteMarcialId).then(response => {
                if(response.status == 200) {
                    this.mostrarNotificacao('Arte marcial removida com sucesso', 'positive');
                    this.listaArtesMarciaisAluno();
                    this.existe = false;
                    this.arteMarcialRemover = {}
                }
            }).catch( e => {
                this.mostrarNotificacao('Houve um erro ao remover a arte marcial', 'warning');
            });
        }
    },
    mounted() {
        this.localizarAluno();      
        this.listaArtesMarciaisAluno();
        this.carregarArtesMarciais();
    }
}

</script>

<style scoped>

    #pagina {
        padding: 20px;
    }

    @media screen and (max-width: 770px) {
        #pagina {
        padding: 5px;
        }
    }

    .formulario {
        border-radius: 10px;
        padding: 30px;
    }

    @media screen and (max-width: 770px) {
        .formulario {
            padding: 15px;
        }
    }

</style>