<template>
  <q-page-container class="flex flex-center">
    <q-card class="campo-login shadow-10 col-5"> 

      <q-form
        class="q-gutter-md" @submit.prevent="entrar()"
      >
        <div class="row justify-start">
          <h5 class="titulo flex flex-center bg-dark text-primary"> Login </h5>
        </div>
        <q-input
          filled
          v-model="user.userName"
          label="Usuário *"
          lazy-rules
          :rules="[ val => val && val.length > 0 || 'Preencha o usuário']"
        />

        <q-input v-model="user.password" 
        filled 
        label="Senha *"
        :type="isPwd ? 'password' : 'text'" 
        lazy-rules
        :rules="[
          val => val !== null && val !== '' || 'Insira sua senha'
        ]">
          <template v-slot:append>
            <q-icon
              :name="isPwd ? 'visibility_off' : 'visibility'"
              class="cursor-pointer"
              @click="isPwd = !isPwd"
            />
          </template>
        </q-input>

        <div>
            <q-btn class="full-width" label="Entrar" type="submit" color="dark" />
        </div>

      </q-form>

    </q-card>
  </q-page-container>
</template>

<script>

  import { useQuasar } from 'quasar'
  import api from 'src/boot/axios.js'

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
                isPwd: true,
                user: {
                    userName: '',
                    password: ''
                }
            }        
        },
        
        methods: {
            entrar() {
                if(this.user.userName.length > 2 && this.user.password.length > 2) {
                    api.entrar(this.user).then(response => {

                            if(response.status == 200) {  
                                localStorage.setItem('token', response.data.token);
                                localStorage.setItem('name', response.data.user.nome);
                                api.getFuncao(response.data.user.id).then(r => {
                                  if(r.status == 200) {
                                    localStorage.setItem('funcao', r.data);
                                    window.location.href = "/" 
                                  }
                                })     
                            }
                    }).catch((e) => {
                        this.showNotif("Usuário e/ou senha inválidos", 'negative');
                    });
                }
            }
        }
    }
</script>

<style scoped>

  .campo-login {
    margin-top: -40px;
    padding: 50px;
    min-width: 45%;
    border-radius: 10px 50px;
  }

  @media screen and (max-width: 720px) {
    .campo-login {
      width: 95%;
      padding: 30px;
    }
  }

  .titulo {
    margin-top: -70px;
    padding: 10px 30px;
    border-radius: 5px;
  }

  @media screen and (max-width: 720px) {
    .titulo {
      margin-left: 3%;
      margin-top: -50px;
      padding: 5px 20px ;
    }
  }

    @media screen and (max-width: 720px) {
    h5 {
      font-size: 1.4em;
    }
  }
</style>