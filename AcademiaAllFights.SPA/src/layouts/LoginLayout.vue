<template>
  <q-layout view="hHh lpR fFf">

    <q-header elevated class="bg-dark text-white q-pa-sm">
      <q-toolbar>
        <q-toolbar-title>
          <img src="~assets/logo1.png" style="height: 50px"/>
        </q-toolbar-title>
      </q-toolbar>
    </q-header>

    <q-page-container>
      <router-view />
    </q-page-container>

  </q-layout>
</template>