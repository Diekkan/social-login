import { Injectable } from '@angular/core';
import { AuthConfig, OAuthService } from 'angular-oauth2-oidc';
import { environment } from '../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private _oAuthService: OAuthService) { }

  setupLogin(){
    const config: AuthConfig = {
      issuer: 'https://accounts.google.com',
      strictDiscoveryDocumentValidation: false,
      clientId: environment.clientId,
      redirectUri: window.location.origin + '/dashboard',
      scope: 'openid profile email'
    }

    this._oAuthService.configure(config);
    this._oAuthService.setupAutomaticSilentRefresh();
    this._oAuthService.loadDiscoveryDocumentAndTryLogin();
  }

  login() {
    this._oAuthService.initLoginFlow();
  }

  logout(){
    this._oAuthService.logOut();
  }

  getInfo(){
    return this._oAuthService.getIdentityClaims();
  }
}
