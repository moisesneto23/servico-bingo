import { Module } from 'vuex';
import { ItemState, state } from './state';
import { RootState } from '@/store';
import mutations from './mutations';
import actions from './actions';
import getters from './getters';


const Item: Module<ItemState, RootState> = {
  actions,
  state,
  mutations,
  getters,
  namespaced: true,
};

export default Item;
