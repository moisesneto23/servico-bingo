<template>
    <div>ola mundo</div>
</template>
<script lang='ts'>
import Rotas from '@/router/Rotas';
import { Vue, Component } from "vue-property-decorator";
import EmpresaModel from "@/Model/Empresa/EmpresaModel";
import EmpresaService from "@/Service/EmpresaService";
import { Inject } from "typescript-ioc";

@Component({
  components:{

  }
})
export default class EtapasCadastroEmpresa extends Vue {
  public drawer = false;
  public group = null;
  public cadastroItens = Rotas.Cadastros.CadastroItens;
  public cadastroProdutos = Rotas.Cadastros.CadastroProdutos;
  public Empresas: EmpresaModel[] = [];
  @Inject
  public empresaService!: EmpresaService;
  public async buscaEmpresas() {
    this.Empresas = await this.empresaService.obterTodasEmpresas();
  }
  
  public Inicio = Rotas.Inicio;
  public CadastroItens = Rotas.Cadastros.CadastroItens;
  public Ajuda = Rotas.Ajuda;
  public RealizaOrcamento = Rotas.Cadastros.RealizaOrcamento;

  public sair(){
    localStorage.removeItem('ocirenegotnemacro');
    this.$router.push(Rotas.Visitante.Login);
  }



}
</script>