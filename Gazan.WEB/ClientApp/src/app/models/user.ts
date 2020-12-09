export class User {
  constructor(
    public id?: string,
    public email?: string,
    public phoneNumber?: string,
    public password?: string,
    public passwordConfirm?: string,
    public role?: string,
  ) {}
}
