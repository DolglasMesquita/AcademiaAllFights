<template>
  <q-page id="pagina">
    <q-card class="area bg-light shadow-10 col-5"> 
      <div align="left" class="q-pa-lg">
        <h5> Olá, {{ nome }} </h5>
        <p class="text-left">
          
        </p>
      </div>
    </q-card>
  </q-page>
</template>

<script>
import { defineComponent } from 'vue';

export default defineComponent({
  name: 'PageIndex',
  data() {
    return {
      nome: ""
    }
  },
  mounted() {
    this.nome = localStorage.getItem('name')
    this.funcao = localStorage.getItem('funcao')
  }
})
</script>

<style scoped>

  .area {
    border-radius: 10px;
  }

  #pagina {
    padding: 40px;
  }

  @media screen and (max-width: 770px) {
    #pagina {
      padding: 15px;
    }
  }
</style>
