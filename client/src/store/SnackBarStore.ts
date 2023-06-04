import { makeAutoObservable } from 'mobx';

import { RootStore } from './RootStore';

export interface SnackBarOptions {
  open: boolean;
  severity: SnackBarSeverity;
  message: string;
}

export type SnackBarSeverity =
  | 'success'
  | 'info'
  | 'warning'
  | 'error'
  | undefined;

export default class SnackBarStore {
  snackBarOptions: SnackBarOptions = {
    open: false,
    severity: undefined,
    message: '',
  };
  rootStore: RootStore;

  constructor(RootStore: RootStore) {
    makeAutoObservable(this);
    this.rootStore = RootStore;
  }

  showSnackBar = (message: string, severity: SnackBarSeverity): void => {
    this.snackBarOptions = {
      open: true,
      severity,
      message,
    };
  };

  closeSnackBar = (): void => {
    this.snackBarOptions = { ...this.snackBarOptions, open: false };
  };
}
