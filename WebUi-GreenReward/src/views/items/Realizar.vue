<template>
  <b-row>
    <b-col>
      <div class="conteudo">
        <h1 class="titulo">Realizar compra</h1>
      </div>

      <div class="container-input">
        <b-form-input
            v-model="cpf"
            autocomplete="off"
            placeholder="CPF"
            class="input"
            style="width: 50%;"
        ></b-form-input>
      </div>

      <div class="conteudo">
        <h4 class="subsubtitulo">*Nome do cadastro no CPF*</h4>
      </div>

      <div class="container-input">
        <b-form-select
            v-model="selected"
            :options="options"
            placeholder="MATERIAL"
            class="input"
            style="width: 50%;height: 2.7rem;padding-left: 9px;"
        ></b-form-select>
      </div>

      <div class="container-input">
        <b-form-input
            v-model="quantidade"
            autocomplete="off"
            placeholder="QUANTIDADE"
            class="input"
            style="width: 50%;"
        ></b-form-input>
      </div>

      <div class="container-input">
        <b-button class="botao input" style="width: 50%;">
          <small class="titulo-botao" @click="exibeToast">ADICIONAR</small>
        </b-button>
      </div>

  </b-col>
  <b-col>

    <div class="conteudo">
      <h1 class="titulo">Valor</h1>
    </div>

    <div class="conteudo-valor">
      <h1 class="titulo-valor">R$999,99</h1>
    </div>

    </b-col>
  </b-row>
</template>

<script>
export default {
  data () {
    return {
      selected: null,
      options: [
        { value: null, text: 'MATERIAL' },
        { text: 'Papelão' },
        { text: 'Plástico' },
        { text: 'Borracha' }
      ]
    }
  },
  methods: {
    exibeToast () {
      // eslint-disable-next-line no-undef
      Toast.fire('Compra realizada!', 'Você pode consultar sua nota fiscal agora.', 'success')
    }
  }
}
</script>

<style>
.conteudo {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 2%;
}
.conteudo-valor {
  display: flex;
  align-items: center;
  justify-content: center;
  margin-top: 12%;
}
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
