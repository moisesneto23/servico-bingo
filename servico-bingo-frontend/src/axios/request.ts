import store from '@/store';

export default (config: any) => {
    const token = ( localStorage.getItem("ocirenegotnemacro")as any);
    if (
        !config.headers.Authorization &&
        token &&
        config.url.indexOf('token') === -1
    ) {
        config.headers.Authorization = token;
    }

    return config;
};
