<template>
    <div >
      <cabecalho-visitante></cabecalho-visitante>
       <router-view></router-view>
    </div>
</template>
<script lang='ts'>
import { Vue, Component } from "vue-property-decorator";
import CabecalhoVisitante from '@/views/visitante/CabecalhoVisitante.vue'
@Component({
  components:{
    CabecalhoVisitante,
  }
})
export default class NavegacaoVisitante extends Vue {

}
</script>
