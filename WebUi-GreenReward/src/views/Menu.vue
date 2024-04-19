<template>
    <div style="margin-bottom: 100px;">
      <div class="menu" :style="{ height: menuExpanded ? '100vh' : '3rem' }">
        <div class="menuItem materiais titulo-menu" @click="showSection('materiais')">Cadastrar</div>
        <div class="menuItem cadastrar titulo-menu" @click="showSection('cadastrar')">Realizar Compra</div>
        <div class="menuItem graficos titulo-menu" @click="showSection('graficos')">Gráficos</div>
        <div class="menuItem historico titulo-menu" @click="showSection('historico')">Histórico</div>
      </div>
      <transition name="slide">
        <div v-if="currentSection === 'materiais'" key="materiais" class="section">
          <cadastrar />
        </div>
      </transition>
      <transition name="slide">
        <div v-if="currentSection === 'cadastrar'" key="cadastrar" class="section">
          <realizar />
        </div>
      </transition>
      <transition name="slide">
        <div v-if="currentSection === 'graficos'" key="graficos" class="section">
          <graficos />
        </div>
      </transition>
      <transition name="slide">
        <div v-if="currentSection === 'historico'" key="historico" class="section">
          <historico />
        </div>
      </transition>

      <div class="footer">
        <div class="left-content">
          <b-button class="botao" @click="login">
            <b-icon icon="arrow-bar-left" style="width: 15px;"></b-icon> SAIR
          </b-button>
        </div>
        <div class="center-content">
          <img src="../assets/footer.png" style="width: 200px;">
        </div>
      </div>

    </div>
  </template>

<script>
import Cadastrar from './items/Cadastrar.vue'
import Graficos from './items/Graficos.vue'
import Historico from './items/Historico.vue'
import Realizar from './items/Realizar.vue'

export default {
  data () {
    return {
      currentSection: null,
      menuExpanded: true
    }
  },
  components: {
    Cadastrar,
    Graficos,
    Historico,
    Realizar
  },
  methods: {
    showSection (section) {
      if (!this.menuExpanded) {
        this.currentSection = section
      } else {
        this.currentSection = section
        this.toggleMenu()
      }
    },
    toggleMenu () {
      this.menuExpanded = !this.menuExpanded
    },
    login () {
      this.$router.push('/login')
    }
  }
}
</script>

<style>
body {
  margin: 0;
  overflow: hidden;
}

.menu {
  display: flex;
  flex-direction: row;
  height: 100vh;
  width: 100vw;
  transition: height 0.5s;
}

.menuItem {
  cursor: pointer;
  flex-grow: 1;
  display: flex;
  justify-content: center;
  align-items: center;
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

.section {
  height: calc(100vh - 3rem);
}

.slide-enter-active, .slide-leave-active {
  transition: transform 0.5s;
}

.slide-enter, .slide-leave-to {
  transform: translateX(100%);
}

.footer {
  position: fixed;
  bottom: 0;
  left: 0;
  width: 100%;
  height: 14%;
  background: linear-gradient(to bottom, #ffffff, #d0d0d0);
  color: white;
  display: flex;
  justify-content: space-between;
  align-items: center;
  border-top: 1px solid black;
}

.left-content {
  display: flex;
  align-items: center;
}

.center-content {
  flex: 1;
  display: flex;
  justify-content: center;
}

.botao {
  background-color: #062800;
  padding: 10px 20px;
  border: 2px solid #062800;
  color: white;
  font-size: 20px;
  border-radius: 40px;
  font-weight: bold;
  margin-left: 20px;
}
  </style>
