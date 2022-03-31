<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Novo aluno </p>

        <q-form @submit.prevent="salvarAluno()"> 
            <div class="q-gutter-md">
                <q-input filled v-model="aluno.nome" label="Nome" />
                <q-input filled v-model="aluno.cpf" label="Cpf" mask="###.###.###-##"/>
                <q-input filled v-model="aluno.telefone" label="Telefone" mask="(##)#####-####"/>
                <q-input filled type="date" v-model="aluno.dataNascimento" hint="Data Nascimento"/>
                
                <div>
                    <q-btn type="submit" color="primary"> Salvar </q-btn>
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
            sucesso() {
                $q.dialog({
                    message: 'aluno cadastrado com sucesso!'
                }).onOk(() => {
                    window.location.href = "/aluno"
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
            artesMarciais: '',
            aluno: {
                nome: '',
                cpf: '',
                telefone: '',
                dataNascimento: ''
            }
        }
    },
    methods: {
        salvarAluno() {

            this.aluno.dataNascimento += "T00:00:00"

            api.postAluno(this.aluno).then(response => {
                if(response.status == 201) {
                    this.sucesso();
                } 

            }).catch(e => {
                this.showNotif('Erro ao salvar aluno, confira os dados e tente novamente')
            });
            
        }
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