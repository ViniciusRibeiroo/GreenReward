<template>
  <div class="container-background">
    <div class="container-banner">
      <img src="../assets/home.png" style="width: 400px;">
    </div>
    <div class="container-botao">
      <b-button class="entrar" @click="login">
        ENTRAR
      </b-button>
    </div>
  </div>
</template>

<script>
export default {
  methods: {
    login () {
      this.$router.push('/login')
    }
  }
}
</script>

<style scoped>
.container-background {
  min-height: calc(87.3vh - 20px);
  padding-bottom: 5px;
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
.entrar {
  background-color: #062800;
  padding: 10px 20px;
  border: 2px solid #062800;
  color: white;
  font-size: 16px;
  border-radius: 40px;
  font-weight: bold;
}
.entrar:hover {
  background-color: #319950;
}
</style>
