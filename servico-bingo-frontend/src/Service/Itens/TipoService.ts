import  TipoModel  from '@/Model/Itens/TipoModel';
import {TipoRepository} from '@/Repository/Itens/TipoRepository';
import { Inject } from 'typescript-ioc';

export default class TipoService {
    
    @Inject
    private _tipoRepository!: TipoRepository;

    public async obterTodosTipos(): Promise<TipoModel[]> {
        return await this._tipoRepository.obterTodosTipos();
    }

    public async salvarTipo(Tipo:TipoModel): Promise<any> {
         await this._tipoRepository.salvarTipo(Tipo);
    }

    public async editarTipo(Tipo:TipoModel): Promise<TipoModel> {
       return await this._tipoRepository.editarTipo(Tipo);
    }
    public async delete(id: number): Promise<any>{
        await this._tipoRepository.delete(id);
    }
};