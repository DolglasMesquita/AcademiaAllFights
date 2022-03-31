<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Novo Usuário </p>

        <q-form @submit.prevent="salvarUsuario()"> 
            <div class="q-gutter-md">
                <q-input filled v-model="usuario.userName" label="Usuário" />
                <q-input filled v-model="usuario.nome" label="Nome" />
                <q-input v-model.trim="usuario.password" filled label="Senha" 
                    :type="isPwd ? 'password' : 'text'" 
                    :rules="[val => !!val || 'Insira uma senha senha', val => val.length > 2 
                    || 'Senha precisa ter no mínimo 3 caracteres']">
                        <template v-slot:append>
                            <q-icon
                            :name="isPwd ? 'visibility_off' : 'visibility'"
                            class="cursor-pointer"
                            @click="isPwd = !isPwd"
                            />
                        </template>
                </q-input> 
                <div>
                    <q-btn type="submit" color="primary"> Salvar </q-btn>
                    <q-btn  to="/usuario" color="secondary" icon-right="arrow_back" class="q-ml-sm" />
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
                    message: 'Usuário cadastrado com sucesso!'
                }).onOk(() => {
                    window.location.href = "/usuario"
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
            isPwd: true,
            usuario: {
                nome: '',
                userName: '',
                password: '',
                confirmPassword: ''
            }
        }
    },
    methods: {
        salvarUsuario() {
            this.usuario.confirmPassword = this.usuario.password

            console.log(this.usuario)
            api.postUsuario(this.usuario).then(response => {
                if(response.status == 201) {
                    this.sucesso();
                } if(response.status == 200) {
                    this.showNotif(response.data)
                }

            }).catch(e => {
                this.showNotif('Erro ao cadastrar usuário')
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