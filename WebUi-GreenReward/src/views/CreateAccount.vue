<template>
  <div class="container-background">
    <div class="container-botao">
      <b-button class="botao">
        CADASTRAR
      </b-button>
    </div>
    <div class="container-botao">
      <b-button class="botao" @click="back">
        VOLTAR
      </b-button>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    back () {
      this.$router.push('/login')
    }
  }
}
</script>

<style scoped>
.container-background {
  background: linear-gradient(to bottom, #ffffff, #d2d2d2);
  min-height: 100vh;
}
.container-banner {
  display: flex;
  justify-content: center;
  align-items: center;
  margin-top: 16vh;
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
}
</style>
