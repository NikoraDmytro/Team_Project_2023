import React, { useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import './UserPage.scss';
import {
  MenuItem,
  Select,
  SelectChangeEvent,
  Chip,
  Button,
  TextField,
  FormControl,
  InputLabel,
} from '@mui/material';
import { UserForm } from '../../components/UserForm';

type User = (typeof test)[0];
type ColumnsType = User & { controls: string };

const UsersPage = () => {
  const [users, setUsers] = useState(test);
  const [open, setOpen] = useState(false);
  const handleClose = () => setOpen(false);

  const columns: TableColumns<User, ColumnsType>[] = [
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
    {
      name: 'role',
      label: 'Роль',
    },
    {
      name: 'controls',
      renderItem: () => (
        <div>
          <EditIcon onClick={() => setOpen(true)} />
          <DeleteIcon className='delete-icon' />
        </div>
      ),
    },
  ];

  const [selectedItems, setSelectedItems] = useState<string[]>([]);

  const handleSelectChange = (event: SelectChangeEvent<string[]>) => {
    setSelectedItems(event.target.value as string[]);
  };
  return (
    <div className='wrapper'>
      <div className='menu'>
        <TextField label='Пошук' className='menu-input' />
        <FormControl>
          <InputLabel id='select-label'>Роль</InputLabel>
          <Select
            multiple
            value={selectedItems}
            onChange={handleSelectChange}
            label='Роль'
            className='menu-input'
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
          className='menu-input'
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
        >
          Додати користувача
        </Button>
      </div>
      <DataTable tableData={users} tableColumns={columns} />
      <UserForm open={open} setClose={handleClose} />
    </div>
  );
};

export { UsersPage };

const test = [
  {
    id: 1,
    name: 'Іванов Іван Іванович',
    membershipCardNum: '123456789',
    role: 'суддя, тренер, адміністратор',
  },
  {
    id: 2,
    name: 'Іванов Іван Іванович',
    membershipCardNum: '123456789',
    role: 'суддя, тренер, адміністратор',
  },
  {
    id: 3,
    name: 'Іванов Іван Іванович',
    membershipCardNum: '123456789',
    role: 'суддя, тренер, адміністратор',
  },
  {
    id: 4,
    name: 'Іванов Іван Іванович',
    membershipCardNum: '123456789',
    role: 'суддя, тренер, адміністратор',
  },
  {
    id: 5,
    name: 'Іванов Іван Іванович',
    membershipCardNum: '123456789',
    role: 'суддя, тренер, адміністратор',
  },
  {
    id: 6,
    name: 'Іванов Іван Іванович',
    membershipCardNum: '123456789',
    role: 'суддя, тренер, адміністратор',
  },
];
