<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Nova Arte Marcial </p>

        <q-form @submit.prevent="salvarArteMarcial()"> 
            <div class="q-gutter-md">
                <q-input filled v-model="arteMarcial.nome" label="Nome" />
            <div>
                    <q-btn type="submit" color="primary"> Salvar </q-btn>
                    <q-btn  to="/artemarcial" color="secondary" icon-right="arrow_back" class="q-ml-sm" />
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
                    message: 'Arte Marcial cadastrada com sucesso!'
                }).onOk(() => {
                    window.location.href = "/artemarcial"
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
            arteMarcial: {
                nome: '',
            }
        }
    },
    methods: {
        salvarArteMarcial() {

            api.postArteMarcial(this.arteMarcial).then(response => {
                if(response.status == 201) {
                    this.sucesso();
                } 

            }).catch(e => {
                this.showNotif('Erro ao salvar arte marcial, confira os dados e tente novamente')
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