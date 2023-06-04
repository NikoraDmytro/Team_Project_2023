import React from 'react';
import ReactDOM from 'react-dom/client';
import { BrowserRouter } from 'react-router-dom';
import { configure } from 'mobx';
import reportWebVitals from './reportWebVitals';
import { App } from './App';
import './index.css';
import RootStore, { RootStoreContext } from './store';

configure({
  enforceActions: 'never',
});

const rootStore = new RootStore();

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement,
);
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <RootStoreContext.Provider value={rootStore}>
        <App />
      </RootStoreContext.Provider>
    </BrowserRouter>
  </React.StrictMode>,
);

reportWebVitals();
