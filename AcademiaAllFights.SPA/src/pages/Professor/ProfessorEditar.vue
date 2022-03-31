<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Editar professor </p>

        <q-form @submit.prevent="editarProfessor()">
            <div class="q-gutter-md">
                <q-input filled v-model="professor.nome" label="Nome" />
                <q-input filled v-model="professor.cpf" label="Cpf" mask="###.###.###-##"/>
                <q-input filled v-model="professor.telefone" label="Telefone" mask="(##)#####-####"/>
                <q-input filled type="date" v-model="professor.dataInicio" label="Data Início" />
                <q-input v-if="!professor.ativo" filled type="date" v-model="professor.dataFim" label="Data Fim" />
                <q-select filled v-model="professor.arteMarcial.nome" :options="options" label="Arte Marcial" />
                <div>
                    <q-btn type="submit" color="primary"> Salvar alterações </q-btn>
                        <q-btn to="/professor" color="secondary" icon-right="arrow_back" class="q-ml-sm" />
                </div>
            </div>
        </q-form>

    </q-card>
  </q-page>
</template>

<script>

import api from 'src/boot/axios.js'
import { useQuasar } from 'quasar'

export default {

    setup () {
        const $q = useQuasar()

        return {
            sucesso() {
                $q.dialog({
                    message: 'Professor editado com sucesso!'
                }).onOk(() => {
                    window.location.href = "/professor"
                }).onCancel(() => {
                    // console.log('Cancel')
                }).onDismiss(() => {
                    // console.log('I am triggered on both OK and Cancel')
                })
            },
             showNotif(mensagem) {
                $q.notify({
                position: 'top',
                message: mensagem,
                color: 'negative'
                })
            }
            
        }
        
    },

    data() {
        return {
            options: [],
            professorEditado: {
                id: '',
                nome: '',
                cpf: '',
                telefone: '',
                dataInicio: '',
                dataFim: '',
                ativo: '',
                arteMarcialId: '',
            },
            professor: {
                id: '',
                nome: '',
                cpf: '',
                telefone: '',
                dataInicio: '',
                dataFim: '',
                ativo: '',
                arteMarcialId: '',
                arteMarcial: {
                    nome: '',
                    ativo: '',
                    id: ''
                }
            }
        }
    },
    methods: {
        localizarProfessor() {
            api.getProfessorById(this.$route.params.id).then(response => {
              if(response.status == 200) { 
                  this.professor = response.data
                  this.professor.dataInicio = response.data.dataInicio.split('T')[0];
                  if(response.data.dataFim != null) {
                    this.professor.dataFim = response.data.dataFim.split('T')[0];
                  }
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

                        obj.value = valor.id
                        obj.label = valor.nome

                        this.options[i] = obj; 
                    });
                }
            }
        )},
        editarProfessor() {
            this.mapeamentoAtualizar()
            console.log(this.professorEditado)

            api.updateProfessor(this.professorEditado, this.professorEditado.id).then(response => {
                if(response.status == 200) {
                    this.sucesso();
                }

            }).catch(e => {
                   this.showNotif('Erro ao editar professor, confira os dados e tente novamente')
                });
            
        },
        mapeamentoAtualizar() {
            if(typeof(this.professor.arteMarcial.nome.value) == 'undefined') {
                this.professorEditado.arteMarcialId = this.professor.arteMarcial.id;
            } else {
                this.professorEditado.arteMarcialId = this.professor.arteMarcial.nome.value;
            }
            this.professorEditado.id = this.professor.id;
            this.professorEditado.nome = this.professor.nome;
            this.professorEditado.cpf = this.professor.cpf;
            this.professorEditado.telefone = this.professor.telefone;
            this.professorEditado.ativo = this.professor.ativo;
            this.professorEditado.dataInicio = this.professor.dataInicio + 'T00:00:00';
            if(this.professor.dataFim != null) {
                this.professorEditado.dataFim = this.professor.dataFim + 'T00:00:00';
            } else {
                this.professorEditado.dataFim = null
            }

        }
        
    },
    mounted() {
        this.localizarProfessor();     
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