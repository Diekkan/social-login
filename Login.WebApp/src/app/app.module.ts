import { NgModule } from "@angular/core";
import { AppComponent } from "./app.component";
import { GoogleLoginProvider, SocialAuthServiceConfig, SocialLoginModule } from "@abacritt/angularx-social-login";
import { DashboardComponent } from "./components/dashboard/dashboard.component";
import { RouterModule, RouterOutlet } from "@angular/router";
import { routes } from "./app.routes";
import { AuthComponent } from "./components/auth/auth.component";
import { LoginComponent } from "./components/auth/login/login.component";
import { RegisterComponent } from "./components/auth/register/register.component";
import { BrowserModule } from "@angular/platform-browser";


@NgModule({
	declarations:
		[
			AppComponent,
			DashboardComponent,
			AuthComponent,
			LoginComponent,
			RegisterComponent
		],
	imports:
		[
			BrowserModule,
			RouterModule.forRoot(routes),
			SocialLoginModule
		],
	providers:
		[
			{
				provide: 'SocialAuthServiceConfig',
				useValue: {
					autoLogin: false,
					providers: [
						{
							id: GoogleLoginProvider.PROVIDER_ID,
							provider: new GoogleLoginProvider('85381869668-ibf2ju2gmboejc8ru08opl3bpogbus2q.apps.googleusercontent.com')
						},
					],
					onError: (err: any) => {
						console.error(err);
					}
				} as SocialAuthServiceConfig,
			}
		],
	bootstrap: [AppComponent],
})
export class AppModule { };