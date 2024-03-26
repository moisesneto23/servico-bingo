import  {AppHttpAxios}  from '@/axios/AppHttpAxios';
import TipoModel from '@/Model/Itens/TipoModel';
import store from '@/store';
import { Inject } from 'typescript-ioc';

export class TipoRepository {
    @Inject
    private $http!: AppHttpAxios;
    private idEmpresa = this.pegaIdEmpresa();
    private pegaIdEmpresa(): number{
        let id = localStorage.getItem('businessId') || '0';
        return parseInt(id);
    }

    public async obterTodosTipos(): Promise<TipoModel[]> {
        const result = await this.$http.get(`TipoItem/${this.idEmpresa}`);
        return result.data;
    }

    public async salvarTipo(Tipo: TipoModel): Promise<any> {
        const result = await this.$http.post(`TipoItem/${this.idEmpresa}`, Tipo);
    }

    public async editarTipo(Tipo: TipoModel): Promise<TipoModel> {     
        const result = await this.$http.patch(`TipoItem/${this.idEmpresa}`, Tipo);
        return result.data;
    }

    public async delete(id: any) : Promise<any>{
        const url = 'TipoItem/'+`${id}`;
        await this.$http.delete(url);
    }
}