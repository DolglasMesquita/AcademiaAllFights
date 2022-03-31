<template>
  <q-page id="pagina">
    <q-card class="formulario">
        <p class="text-h5 q-pb-lg"> Tipos de Input </p>

        <q-form class="bg-gray">
            <div class="q-gutter-md">

      <q-input filled v-model="text" label="Label" :dense="dense" />

      <q-input type="number" filled v-model="numero" label="Label" :dense="dense" />

      <q-input filled v-model="text" label="Label" placeholder="Placeholder" hint="With placeholder" :dense="dense" />

      <q-input filled v-model="data" :dense="dense" mask="##/##/####">
        <template v-slot:prepend>
          <q-icon name="event" />
        </template>
      </q-input>

      <q-input filled bottom-slots v-model="text" label="Label" counter :dense="dense">
        <template v-slot:prepend>
          <q-icon name="place" />
        </template>
        <template v-slot:append>
          <q-icon name="close" @click="text = ''" class="cursor-pointer" />
        </template>

        <template v-slot:hint>
          Field hint
        </template>
      </q-input>

      <q-input filled bottom-slots v-model="text" label="Label" counter maxlength="12" :dense="dense">
        <template v-slot:before>
          <q-icon name="flight_takeoff" />
        </template>

        <template v-slot:append>
          <q-icon v-if="text !== ''" name="close" @click="text = ''" class="cursor-pointer" />
          <q-icon name="search" />
        </template>

        <template v-slot:hint>
          Field hint
        </template>
      </q-input>
        

    <q-input
      v-model="text"
      filled
      type="textarea"
      label="Text Area"
    />

     <q-select filled v-model="model" :options="options" label="Select" />


     <q-radio v-model="check" val="line" label="Line"/>
      <q-radio val="rectangle" label="Rectangle" />
      <q-radio val="ellipse" label="Ellipse" />
      <q-radio val="polygon" label="Polygon" />

    <br>

            <q-checkbox dense v-model="check" label="Teal" color="teal" />
      <q-checkbox dense v-model="check" label="Orange" color="orange" />
      <q-checkbox dense v-model="check" label="Red" color="red" />
            
        </div>
    </q-form>

    </q-card>
  </q-page>
</template>

<script>

export default {

    data() {
        return {
            text: '',
            dense: false,
            ph: '',
            data: '',
            model: null,
            options: ['Google', 'Facebook', 'Twitter', 'Apple', 'Oracle'],
            check: false,
            numero: ''
        }
    } 
}

</script>

<style scoped>

    #pagina {
        padding: 30px 100px;
    }

    @media screen and (max-width: 770px) {
        #pagina {
        padding: 5px;
        }
    }

    .formulario {
        border-radius: 10px;
        padding: 50px;
    }

    @media screen and (max-width: 770px) {
        .formulario {
            padding: 35px;
        }
    }

</style>