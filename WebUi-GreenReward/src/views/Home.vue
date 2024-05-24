<template>
  <div>
    <header>
      <div class="logo">
        <h1>Green Reward</h1>
      </div>
      <div class="nav-buttons">
        <nav>
          <ul>
            <li><a href="#">Início</a></li>
            <li><a href="#">Contatos</a></li>
            <li><a href="#" @click="login">Entrar</a></li>
            <li><a href="#" @click="login">Cadastre-se</a></li>
          </ul>
        </nav>
      </div>
    </header>

    <main>
      <section>
        <h2 class="titulo mt-4">FACILITE A COLETA DE RESÍDUOS NO SEU MUNICÍPIO</h2>
      </section>
    </main>

    <img src="../assets/banner.png" class="banner">

    <div class="conteudo">
      <h2 class="titulo">ENTENDA O QUE QUEREMOS TE PROPORCIONAR</h2>
    </div>

    <footer>
      <p>&copy; 2024 Green Reward. Todos os direitos reservados.</p>
    </footer>
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
header {
  background-color: #062800;
  color: #fff;
  padding: 20px;
  display: flex;
  justify-content: space-between;
  align-items: center;
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  z-index: 1000;
}

.logo {
  flex: 1;
}

.nav-buttons {
  flex: 1;
  text-align: right;
}

nav ul {
  list-style: none;
  padding: 0;
}

nav ul li {
  display: inline;
  margin-right: 20px;
}

nav ul li a {
  color: #fff;
  text-decoration: none;
}

main {
  padding: 20px;
  text-align: center;
  margin-top: 80px;
}

footer {
  background-color: #062800;
  color: #fff;
  padding: 20px;
  text-align: center;
  position: relative;
}

.banner {
  width: 100%;
}

.background-image {
  position: fixed;
  top: 0;
  left: 0;
  width: 100%;
  height: 100%;
  z-index: -1;
  opacity: 0.5;
}

.conteudo {
  padding: 20px;
  text-align: center;
  margin-top: 35px;
}
</style>
