<template>
  <q-page id="pagina" class="row">
    <q-card class="formulario col-12 col-lg-6">
        <p class="text-h4 q-pb-lg"> Editar Arte Marcial </p>

        <q-form @submit.prevent="editarArteMarcial()">
            <div class="q-gutter-md">
                <q-input filled v-model="arteMarcial.nome" label="Nome" />
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
                    message: 'Arte Marcial editada com sucesso!'
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
                id: '',
                nome: '',
                ativo: ''
            }
        }
    },
    methods: {
        localizarArteMarcial(){
            api.getArteMarcialId(this.$route.params.id).then(response => {
              if(response.status == 200) { 
                  this.arteMarcial = response.data
                }
            });
        },
        editarArteMarcial() {
            api.updateArteMarcial(this.arteMarcial, this.arteMarcial.id).then(response => {
                if(response.status == 200) {
                    this.sucesso();
                }

            }).catch(e => {
                this.showNotif('Erro ao editar arte macial, confira os dados e tente novamente')
            });
        }
        
    },
    mounted() {
        this.localizarArteMarcial();     
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