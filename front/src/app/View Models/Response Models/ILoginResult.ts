import { IJwtAuth } from "./IJwtAuth";

export interface ILoginResult {
  userName: string;
  roles:string[];
  authReslut:IJwtAuth;
}
