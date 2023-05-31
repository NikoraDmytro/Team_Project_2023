import React, { useState } from 'react';
import {
  Button,
  Dialog,
  MenuItem,
  Select,
  Chip,
  FormControl,
  InputLabel,
  SelectChangeEvent,
} from '@mui/material';
import { Formik, Form } from 'formik';
import ClearIcon from '@mui/icons-material/Clear';
import { InputFormField } from '../InputFormField';

interface FormValues {
  email: string;
  password: string;
  role: string;
  name: string;
}

const initialValues: FormValues = {
  email: '',
  password: '',
  role: '',
  name: '',
};

interface UserFormProps {
  open: boolean;
  setClose: () => void;
}

const UserForm = (props: UserFormProps) => {
  const { open, setClose } = props;
  const [selectedItems, setSelectedItems] = useState<string[]>([]);

  const submitHandler = (values: FormValues) => {
    console.log(values);
    setClose();
  };

  const handleSelectChange = (event: SelectChangeEvent<string[]>) => {
    setSelectedItems(event.target.value as string[]);
  };
  return (
    <Dialog open={open} onClose={setClose}>
      <Formik initialValues={initialValues} onSubmit={submitHandler}>
        {() => (
          <Form className='form'>
            <InputFormField
              label='Електронна адреса'
              name='email'
              type='Email'
            />
            <InputFormField label='Пароль' name='password' type='text' />
            <InputFormField label='ПІБ' name='name' type='text' />
            <FormControl>
              <InputLabel id='select-label'>Роль</InputLabel>
              <Select
                multiple
                value={selectedItems}
                onChange={handleSelectChange}
                label='Роль'
                className='irole-input'
                renderValue={selected => (
                  <div style={{ display: 'flex', flexWrap: 'wrap' }}>
                    {(selected as string[]).map(item => (
                      <Chip key={item} label={item} style={{ margin: '2px' }} />
                    ))}
                  </div>
                )}
              >
                <MenuItem value='суддя'>Суддя</MenuItem>
                <MenuItem value='тренер'>Тренер</MenuItem>
                <MenuItem value='адміністратор'>Адміністратор</MenuItem>
              </Select>
            </FormControl>
            <Button
              type='submit'
              variant='contained'
              color='primary'
              size='large'
              sx={{ width: '60%' }}
            >
              Зберегти
            </Button>
            <ClearIcon className='close-icon' onClick={setClose} />
          </Form>
        )}
      </Formik>
    </Dialog>
  );
};

export { UserForm };
