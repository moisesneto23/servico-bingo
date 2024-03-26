import Axios, { AxiosInstance, AxiosPromise, AxiosRequestConfig } from 'axios'
import Request from '@/axios/request';
import router from '@/router';
import Rotas from '@/router/Rotas';

export class AppHttpAxios {
  public axiosInstance: AxiosInstance;

  //meu construtor
  constructor() {
    this.axiosInstance = Axios.create({
      baseURL : 'http://192.168.3.10:7058/api/'
    });
    this.axiosInstance.interceptors.request.use(Request);
    this.axiosInstance.defaults.headers.common['Authorization'] = localStorage.getItem('ocirenegotnemacro') || '';
    this.axiosInstance.interceptors.response.use(function (response) {
      return response;
    }, function (error) {
      if(error.response.status === 404 || error.response.status === 401){
        alert(error.response.data.detail);
        router.push(Rotas.Visitante.Login);
      }
      if(error.response.status === 400 ){
        alert(error.response.data.detail);
      }
      return Promise.reject(error);
    });
  }


  public get<T = any>(url: string, config?: AxiosRequestConfig): AxiosPromise<T> {
    return this.axiosInstance.get(url, config);
  }

  public post<T = any>(url: string, data?: any): AxiosPromise<T> {
    return this.axiosInstance.post(url, data);
  }

  public patch<T = any>(url: string, data?: any): AxiosPromise<T> {
    return this.axiosInstance.patch(url, data);
  }

  public put<T = any>(url: string, data?: any): AxiosPromise<T> {
    return this.axiosInstance.put(url, data);
  }
  
  public delete(url: string): AxiosPromise {
    return this.axiosInstance.delete(url);
  }

  public head(url: string): AxiosPromise {
    return this.axiosInstance.head(url);
  }
}
const http = new AppHttpAxios();
export default http;
