import InformacoesEmpresa from '@/Model/InformacoesEmpresa'

export class GlobalState {

    public informacoesEmpresa!: InformacoesEmpresa;

    constructor() {
      this.informacoesEmpresa; 
    }
  }

export const state: GlobalState = new GlobalState();