<template>
  <div>
    <header>
      <div class="logo">
        <img src="../assets/footer.png" style="width: 10rem;">
      </div>
      <div class="nav-buttons">
        <nav>
          <ul>
            <li><a href="#">Início</a></li>
            <li><a href="#">Contatos</a></li>
            <li><a href="#" @click="login">Entrar</a></li>
            <b-button class="botao" @click="cadastrar">
              Cadastre-se
            </b-button>
          </ul>
        </nav>
      </div>
    </header>

    <main>
      <section>
        <h2 class="titulo mt-5">FACILITE A COLETA DE RESÍDUOS NO SEU MUNICÍPIO</h2>
      </section>
    </main>

    <div class="banner-container">
      <img src="../assets/banner.png" class="banner">
      <b-button @click="login" class="botao-adquira">
        <h5 class="titulo-adquira">Adquirir já!</h5>
      </b-button>
    </div>

    <div class="conteudo">
      <h2 class="titulo" style="color: #062800;">ENTENDA O QUE QUEREMOS TE PROPORCIONAR</h2>
    </div>

    <div class="menu">
      <div class="menuItem materiais">
        <h1 class="titulo-menu-home">
          FACILITAR A COLETA DE RESÍDUOS RECICLÁVEIS
        </h1>
      </div>
      <div class="menuItem cadastrar">
        <h1 class="titulo-menu-home">
          EDUCAR A POPULAÇÃO
        </h1>
      </div>
      <div class="menuItem graficos">
        <h1 class="titulo-menu-home">
          TRANSFORMAR A RECICLAGEM EM UM NEGÓCIO LUCRATIVO
        </h1>
      </div>
      <div class="menuItem historico">
        <h1 class="titulo-menu-home">
          MANUTENÇÃO DO BIOSISTEMA
        </h1>
      </div>
    </div>

    <footer>
      <p>&copy; 2024 Green Reward. Todos os direitos reservados.</p>
    </footer>
  </div>
</template>

<script>
export default {
  mounted () {
    window.addEventListener('scroll', this.handleScroll)
    this.handleScroll()
  },
  destroyed () {
    window.removeEventListener('scroll', this.handleScroll)
  },
  methods: {
    handleScroll () {
      const menu = document.querySelector('.menu')
      const distanciaTopo = menu.getBoundingClientRect().top
      const alturaJanela = window.innerHeight
      const elementosAnimados = document.querySelectorAll('.menu .titulo-menu-home')

      if (distanciaTopo < alturaJanela * 0.75) {
        elementosAnimados.forEach(elemento => {
          elemento.classList.add('animacao-rolagem')
        })
      } else {
        elementosAnimados.forEach(elemento => {
          elemento.classList.remove('animacao-rolagem')
        })
      }
    },
    login () {
      this.$router.push('/login')
    },
    cadastrar () {
      this.$router.push('/create-account')
    }
  }
}
</script>

<style scoped>
header {
  background-color: #fff;
  color: #062800;
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
  color: #062800;
  font-weight: bold;
}
main {
  background-color: #062800;
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
.conteudo {
  padding: 20px;
  text-align: center;
  margin-top: 35px;
}
.titulo {
  color: #fff;
}
.botao-adquira {
  background-color: #062800;
  padding: 10px 20px;
  border: 2px solid #062800;
  color: white;
  font-size: 2rem;
  border-radius: 40px;
  font-weight: bold;
  margin-top: 6rem;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
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
.botao:hover {
  background-color: #319950;
}
.banner-container {
  position: relative;
  text-align: center;
}
.menu {
  display: flex;
  flex-direction: row;
}
.menuItem {
  flex-grow: 1;
  display: flex;
  justify-content: center;
  align-items: center;
  width: 25%;
  height: 40rem;
}
.materiais {
  background-color: #062800;
}
.cadastrar {
  background-color: #13430A;
}
.graficos {
  background-color: #225B18;
}
.historico {
  background-color: #347329;
}
.left-content {
  display: flex;
  align-items: center;
}
@keyframes fadeInUp {
  from {
    opacity: 0;
    transform: translateY(15rem);
  }
  to {
    opacity: 1;
    transform: translateY(0);
  }
}
.animacao-rolagem {
  animation: fadeInUp 4s ease-out forwards;
}
</style>
