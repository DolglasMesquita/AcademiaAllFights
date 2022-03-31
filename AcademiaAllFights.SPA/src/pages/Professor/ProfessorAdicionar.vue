<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Novo professor </p>

        <q-form @submit.prevent="salvarProfessor()" to="/professor"> 
            <div class="q-gutter-md">
                <q-input filled v-model="professor.nome" label="Nome" />
                <q-input filled v-model="professor.cpf" label="Cpf" mask="###.###.###-##"/>
                <q-input filled v-model="professor.telefone" label="Telefone" mask="(##)#####-####"/>
                <q-select filled v-model="artesMarciais" :options="options" label="Arte Marcial" />
                
                <div>
                    <q-btn type="submit" color="primary"> Salvar </q-btn>
                    <q-btn  to="/professor" color="secondary" icon-right="arrow_back" class="q-ml-sm" />
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
            sucesso() {
                $q.dialog({
                    message: 'Professor cadastrado com sucesso!'
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
            artesMarciais: '',
            professor: {
                nome: '',
                cpf: '',
                telefone: '',
                arteMarcialId: ''
            }
        }
    },
    methods: {
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
        salvarProfessor() {
            this.professor.arteMarcialId = this.artesMarciais.value

            api.postProfessor(this.professor).then(response => {
                if(response.status == 201) {
                    this.sucesso();
                } 

            }).catch(e => {
                this.showNotif('Erro ao salvar professor, confira os dados e tente novamente')
            });
            
        }
    },
    mounted() {
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