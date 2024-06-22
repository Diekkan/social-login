import { Routes } from '@angular/router';
import { LoginComponent } from './components/auth/login/login.component';
import { AuthComponent } from './components/auth/auth.component';
import { RegisterComponent } from './components/auth/register/register.component';

export const routes: Routes = [
    {
        path: "auth", component: AuthComponent,
        children: 
        [
            { path: "login", component: LoginComponent },
            { path: "register", component: RegisterComponent}
        ]
    },
    { path: '', redirectTo: '/auth/login', pathMatch: "full" },

];
