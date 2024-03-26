import  InformacoesEmpresa from '@/Model/InformacoesEmpresa';
import { MutationTree } from 'vuex';
import { GlobalState } from './state';

export enum GlobalMutationTypes {
  SET_FAZER_LOGIN = 'SET_FAZER_LOGIN',
}

const mutations: MutationTree<GlobalState> = {

  [GlobalMutationTypes.SET_FAZER_LOGIN](state: GlobalState, informacoesEmpresa: InformacoesEmpresa) {
    state.informacoesEmpresa = informacoesEmpresa;
  },
};

export default mutations;
