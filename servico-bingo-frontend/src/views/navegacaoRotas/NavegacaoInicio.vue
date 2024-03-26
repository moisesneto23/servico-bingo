<template>
  <div>
    <cabecalho></cabecalho>

    <router-view></router-view>
    
  </div>
</template>

<script lang="ts">

import Cabecalho from '@/components/Cabecalho.vue';
import { Component, Vue, Prop } from 'vue-property-decorator';

@Component({
  components: {
    Cabecalho
  }
})
export default class NavegacaoInicio extends Vue{
 
};
</script>
