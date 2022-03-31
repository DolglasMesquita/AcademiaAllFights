<template>
  <q-layout view="lHh Lpr lFf">
    <q-header elevated class="bg-dark q-pa-sm">
      <q-toolbar>
        <q-btn
          flat
          dense
          round
          icon="menu"
          aria-label="Menu"
          color="primary"
          @click="toggleLeftDrawer"
        />

        <q-toolbar-title align="left">
          <router-link  to="/"> <img src="~assets/logo1.png" style="height: 50px"/> </router-link>
        </q-toolbar-title>        
      </q-toolbar>
    </q-header>

    <q-drawer
      v-model="leftDrawerOpen"
      show-if-above
      bordered
      class="bg-grey-1"
    >
      <q-scroll-area id="menu">
        <q-list padding class="text-dark">

            <q-item clickable v-ripple to="/aluno/public">
              <q-item-section avatar>
                <q-icon name="groups" size="md"/>
              </q-item-section>

              <q-item-section>
                Alunos
              </q-item-section>
            </q-item>


            <q-item clickable v-ripple to="/professor/public">
              <q-item-section avatar>
                <q-icon name="group" size="md" />
              </q-item-section>

              <q-item-section>
                Professores
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple to="/artemarcial/public">
              <q-item-section avatar>
                <q-icon name="sports_kabaddi" size="md"/>
              </q-item-section>

              <q-item-section>
                Artes marciais
              </q-item-section>
            </q-item>
            
          </q-list>
          <q-list v-if="funcao == 'Admin'" padding class="text-dark">

            <q-item>

              <q-item-section>
                <span class="text-h6"> Área administrativa </span>
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple to="/aluno">
              <q-item-section avatar>
                <q-icon name="settings" size="sm"/>
              </q-item-section>

              <q-item-section>
                Gerenciar Alunos
              </q-item-section>
            </q-item>


            <q-item clickable v-ripple to="/professor">
              <q-item-section avatar>
                <q-icon name="settings" size="sm" />
              </q-item-section>

              <q-item-section>
                Gerenciar Professores
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple to="/artemarcial">
              <q-item-section avatar>
                <q-icon name="settings" size="sm"/>
              </q-item-section>

              <q-item-section>
                Gerenciar Artes marciais
              </q-item-section>
            </q-item>

            <q-item clickable v-ripple to="/usuario">
              <q-item-section avatar>
                <q-icon name="manage_accounts" size="sm"/>
              </q-item-section>

              <q-item-section>
                Gerenciar Usuários
              </q-item-section>
            </q-item>

            
          </q-list>
        </q-scroll-area>

          <q-img class="absolute-top bg-grey-7" style="height: 150px">
          <div class="absolute-bottom">
            <q-avatar size="70px" class="" icon="account_circle"/>
            <div class="text-weight-bold text-h6"> {{ nome }} </div>
            <div>
              <q-btn icon="logout" color="primary" text-color="dark" size="md" dense class="q-ml-xs" @click="deslogar()"/>
            </div>
          </div>
        </q-img>
    </q-drawer>

    <q-page-container>
      <router-view />
    </q-page-container>
  </q-layout>
</template>

<script>

import { defineComponent, ref } from 'vue'

export default defineComponent({
  name: 'MainLayout',

  components: {

  },

  data() {
    return {
      nome: '',
      funcao: ''
    }
  },
  methods: {
    deslogar() {
      localStorage.clear();
      window.location.href = '/#/login';
    }
  },
  mounted() {
    this.nome = localStorage.getItem('name')
    this.funcao = localStorage.getItem('funcao')
  },

  setup () {
    const leftDrawerOpen = ref(false)

    return {
      leftDrawerOpen,
      toggleLeftDrawer () {
        leftDrawerOpen.value = !leftDrawerOpen.value
      }
    }
  }
})
</script>

<style scoped>
  #menu {
    height: calc(100% - 150px); 
    margin-top: 150px; border-right: 
    1px solid #ddd
  }

  a {
    color: #000;
  }
</style>
