import classes from "./Login.module.css";
import "@digdir/design-system-tokens/brand/digdir/tokens.css";
import { Button, Heading, Textfield } from "@digdir/design-system-react";
import React, { FormEvent, useState } from "react";
import { useNavigate } from "react-router-dom";
import { axiosPostForm, getApiUrl, validateLoginForm } from "./LoginUtils";
import { LoginForm, LoginFormError } from "./types";

export const Login = (): React.JSX.Element => {
  const navigate = useNavigate();
  const [formErrors, setFormErrors] = useState<LoginFormError | null>(null);

  const handleSubmit = async (event: FormEvent<HTMLFormElement>) => {
    event.preventDefault();

    const formData = new FormData(event.currentTarget as HTMLFormElement);
    const loginForm: LoginForm = Object.fromEntries(formData);
    const formIsValid: boolean = validateLoginForm({ loginForm, setFormErrors });
    
    if (formIsValid) {
      const apiUrl = getApiUrl();
      const targetUrl = `${apiUrl}/api/auth/login`;
      await axiosPostForm(targetUrl, formData) && navigate("/dashboard");
    }
  };

  return (
    <form onSubmit={handleSubmit} className={classes.loginContainer} noValidate>
      <Heading level={1} size="xlarge">
        Log in
      </Heading>
      <div className={classes.fieldContainer}>
        <Textfield name="email" type="email" label="E-mail" error={formErrors?.email} />
        <Textfield name="password" type="password" label="Password" error={formErrors?.password} />
      </div>
      <div className={classes.buttonContainer}>
        <Button type="submit" className={classes.button}>
          Log in
        </Button>
        <Button className={classes.button} asChild variant="secondary" size="small">
          <a href="/signup">Go to the sign up page</a>
        </Button>
      </div>
    </form>
  );
};
