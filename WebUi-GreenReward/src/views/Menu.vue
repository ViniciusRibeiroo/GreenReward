<template>
    <div>
      <div class="menu">
        <div class="menuItem" @click="showSection('materiais')">Cadastrar Materiais</div>
        <div class="menuItem" @click="showSection('cadastrar')">Cadastrar Venda</div>
        <div class="menuItem" @click="showSection('graficos')">Gráficos</div>
        <div class="menuItem" @click="showSection('historicos')">Históricos</div>
      </div>
      <transition name="slide">
        <div v-if="currentSection === 'materiais'" key="materiais" class="section">
          <h1>Cadastrar Materiais</h1>
        </div>
      </transition>
      <transition name="slide">
        <div v-if="currentSection === 'cadastrar'" key="cadastrar" class="section">
          <h1>Cadastrar Venda</h1>
        </div>
      </transition>
      <transition name="slide">
        <div v-if="currentSection === 'graficos'" key="graficos" class="section">
          <h1>Gráficos</h1>
        </div>
      </transition>
      <transition name="slide">
        <div v-if="currentSection === 'historicos'" key="historicos" class="section">
          <h1>Históricos</h1>
        </div>
      </transition>
    </div>
  </template>

<script>
export default {
  data () {
    return {
      currentSection: null
    }
  },
  methods: {
    showSection (section) {
      this.currentSection = section
    }
  }
}
</script>

  <style>
  .menu {
    display: flex;
    justify-content: space-around;
    background-color: lightgreen;
  }

  .menuItem {
    cursor: pointer;
  }

  .section {
    height: 100vh;
  }

  .slide-enter-active, .slide-leave-active {
    transition: transform 0.5s;
  }

  .slide-enter, .slide-leave-to {
    transform: translateX(100%);
  }
  </style>
