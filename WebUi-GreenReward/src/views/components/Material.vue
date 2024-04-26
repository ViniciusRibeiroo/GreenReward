<template>
    <div>

      <div class="container-banner">
        <h1 class="titulo">Adicionar material</h1>
      </div>

      <div class="container-input">
        <b-form-input
          v-model="material"
          autocomplete="off"
          placeholder="*MATERIAL"
          class="input"
        ></b-form-input>
      </div>
      <div class="container-input">
        <b-form-input
          v-model="unidade"
          autocomplete="off"
          placeholder="*UNIDADE DE MEDIDA"
          class="input"
        ></b-form-input>
      </div>

      <div class="container-input">
        <b-form-input
          v-model="valor"
          autocomplete="off"
          placeholder="*VALOR"
          class="input"
        ></b-form-input>
      </div>

    </div>
  </template>

<script>

</script>

<style scoped>
.container-banner {
display: flex;
justify-content: center;
align-items: center;
margin-top: 2%;
}
.container-input {
display: flex;
justify-content: center;
align-items: center;
margin-top: 3vh;
margin-bottom: 3vh;
}
.container-botao {
margin-top: 4vh;
display: flex;
justify-content: center;
align-items: center;
}
.botao {
background-color: #062800;
padding: 10px 20px;
border: 2px solid #062800;
color: white;
font-size: 16px;
border-radius: 40px;
font-weight: bold;
margin-right: 1rem;
}
.botao:hover {
background-color: #319950;
}
.input {
width: 25%;
border-width: 0.215rem;
border-color: black;
border-radius: 30px;
}
</style>
