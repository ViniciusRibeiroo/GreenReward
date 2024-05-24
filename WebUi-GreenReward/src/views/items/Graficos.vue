<template>
  <b-row>
    <div class="conteudo">
      <h1 class="titulo">Gráficos</h1>
    </div>

    <b-col class="conteudo-grafico">
      <img src="../../assets/graficos.png" style="width: 40rem;">
    </b-col>
    <b-col class="conteudo-filtros">
      <div class="container-input">
        <b-form-select
            v-model="selected"
            :options="eixoX"
            placeholder="Eixo X"
            class="input"
            style="width: 20rem;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>
      <div class="container-input">
        <b-form-select
            v-model="selected"
            :options="filtrarEixoX"
            placeholder="Filtrar Eixo X"
            class="input"
            style="width: 20rem;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>
      <div class="container-input">
        <b-form-select
            v-model="selected"
            :options="eixoY"
            placeholder="Eixo Y"
            class="input"
            style="width: 20rem;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>
      <div class="container-input">
        <b-form-select
            v-model="selected"
            :options="filtrarEixoY"
            placeholder="Filtrar Eixo Y"
            class="input"
            style="width: 20rem;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>
    </b-col>
  </b-row>
</template>

<script>
export default {
  data () {
    return {
      selected: null,
      eixoX: [
        { value: null, text: 'Eixo X' },
        { text: '----------' }
      ],
      filtrarEixoX: [
        { value: null, text: 'Filtrar Eixo X' },
        { text: '----------' }
      ],
      eixoY: [
        { value: null, text: 'Eixo Y' },
        { text: '----------' }
      ],
      filtrarEixoY: [
        { value: null, text: 'Filtrar Eixo Y' },
        { text: '----------' }
      ]
    }
  }
}
</script>

<style>
.conteudo {
  align-items: center;
  justify-content: center;
  margin-top: 2%;
}
.conteudo-grafico {
  display: flex;
  align-items: center;
  justify-content: center;
}
.conteudo-filtros {
  display: block;
  align-items: center;
  justify-content: center;
}
.input {
  border-width: 0.215rem;
  border-color: black;
  border-radius: 30px;
}
.container-input {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 3vh;
  margin-bottom: 3vh;
}
</style>
