import { IJwtAuth } from "./IJwtAuth";

export interface ILoginResult {
  userName: string;
  roles:string[];
  authResult:IJwtAuth;
}
