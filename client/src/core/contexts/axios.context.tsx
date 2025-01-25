import axios, {
  AxiosInstance,
  AxiosInterceptorOptions,
  AxiosResponse,
  CreateAxiosDefaults,
  InternalAxiosRequestConfig
} from 'axios';
import React from 'react';

type AxiosProviderProps = {
  config: CreateAxiosDefaults;
  requestInterceptors?: {
    (value: InternalAxiosRequestConfig): InternalAxiosRequestConfig | Promise<InternalAxiosRequestConfig>;
    onRejected: (error: unknown) => void;
    options: AxiosInterceptorOptions;
  }[];
  responseInterceptors?: {
    (value: AxiosResponse): AxiosResponse | Promise<AxiosResponse>;
    onRejected: (error: unknown) => void;
    options: AxiosInterceptorOptions;
  }[];
  children: React.ReactNode;
};

const AxiosContext = React.createContext<AxiosInstance | undefined>(undefined);

export function AxiosInstanceProvider({
  config,
  requestInterceptors,
  responseInterceptors,
  children
}: AxiosProviderProps) {
  const instanceRef = React.useRef<AxiosInstance>(axios.create(config));

  React.useEffect(() => {
    if (requestInterceptors) {
      // eslint-disable-next-line unicorn/no-array-for-each
      requestInterceptors.forEach(interceptor => instanceRef.current.interceptors.request.use(interceptor));
    }

    if (responseInterceptors) {
      // eslint-disable-next-line unicorn/no-array-for-each
      responseInterceptors.forEach(interceptor => instanceRef.current.interceptors.response.use(interceptor));
    }
  }, [requestInterceptors, responseInterceptors]);

  return <AxiosContext.Provider value={instanceRef.current}>{children}</AxiosContext.Provider>;
}

export function useAxios() {
  const context = React.useContext(AxiosContext);
  if (!context) {
    throw new Error('useAxios cannot be used outside of an AxiosInstanceProvider');
  }

  return context;
}
