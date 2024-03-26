import { AppHttpAxios } from '@/axios/AppHttpAxios';
import EmpresaModel from '@/Model/Empresa/EmpresaModel';
import Login from '@/Model/Login';
import { Inject } from 'typescript-ioc';
import InformacoesEmpresa  from '../Model/InformacoesEmpresa';

export class EmpresaRepository  {
    
    @Inject
    private $http!: AppHttpAxios;
    
    public async obterEmpresas(): Promise<EmpresaModel[]> { 
        const result = await this.$http.get('Empresa');
        return result.data;
    }

    public async obterInformacoesEmpresa(login: Login): Promise<InformacoesEmpresa> {
        const res = await this.$http.post('Usuario/Login',login);
        console.log(res.data);
        return res.data;
    }
}

/*public async obterAtividadesTCC(): Promise<DisciplinaExtraCurricularModel[]> {

    const result = await this.$http.get(`${this.endpointBase}api/dispensa/trabalhoConclusaoCurso`, {params: { codigoAluno }});
    return result.data;
}*/