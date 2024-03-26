import { Module } from 'vuex';
import { ProdutoState, state } from './state';
import { RootState } from '@/store';
import mutations from './mutations';
import actions from './actions';
import getters from './getters';


const Produto: Module<ProdutoState, RootState> = {
  actions,
  state,
  mutations,
  getters,
  namespaced: true,
};

export default Produto;
