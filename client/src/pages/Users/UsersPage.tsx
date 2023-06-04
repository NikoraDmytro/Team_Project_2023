import React, { useEffect, useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import './UserPage.scss';
import { Button, TextField } from '@mui/material';
import { UserForm } from '../../components/UserForm';
import { User } from '../../models/User';
import { UserService } from '../../services';

type ColumnsType = User & { controls: string };

const UsersPage = () => {
  const [users, setUsers] = useState<User[]>([]);
  const [filteredUsers, setFilteredUsers] = useState<User[]>([]);
  const [filterValue, setFilterValue] = useState('');
  const [open, setOpen] = useState(false);
  const [update, setUpdate] = useState(false);
  const [user, setUser] = useState<User>();
  const handleClose = () => setOpen(false);

  const fetchUsers = async () => {
    const response = await UserService.getAllUsers();
    const data = response.map(user => ({
      id: user.id,
      email: user.email,
      firstName: user.firstName,
      lastName: user.lastName,
      patronymic: user.patronymic,
    }));

    setUsers(data);
    setFilteredUsers(data);
  };

  const handleFilterChange = (event: any) => {
    setFilterValue(event.target.value);
    setFilteredUsers(filteredItems);
  };

  const deleteUser = async (id: number) => {
    await UserService.deleteUser(id);
    fetchUsers();
  };

  const filteredItems = users.filter(user => {
    if (!filterValue) return true;
    console.log(filterValue);
    return (
      user.firstName?.toLowerCase().includes(filterValue.toLowerCase()) ||
      user.lastName?.toLowerCase().includes(filterValue.toLowerCase()) ||
      user.patronymic?.toLowerCase().includes(filterValue.toLowerCase())
    );
  });

  const editUser = (item: User) => {
    setUpdate(true);
    setUser(item);
    setOpen(true);
  };

  const createUser = () => {
    setUpdate(false);
    setOpen(true);
  };

  useEffect(() => {
    fetchUsers();
  }, []);

  const columns: TableColumns<User, ColumnsType>[] = [
    {
      name: 'id',
      label: 'Id',
    },
    {
      name: 'email',
      label: 'Email',
      sortable: true,
    },
    {
      name: 'firstName',
      label: "Ім'я",
      sortable: true,
    },
    {
      name: 'lastName',
      label: 'Прізвище',
      sortable: true,
    },
    {
      name: 'patronymic',
      label: 'По-батькові',
      sortable: true,
    },
    {
      name: 'controls',
      renderItem: (item: User) => (
        <div>
          <EditIcon onClick={() => editUser(item)} />
          <DeleteIcon
            onClick={() => deleteUser(item.id)}
            className='delete-icon'
          />
        </div>
      ),
    },
  ];

  return (
    <div className='wrapper'>
      <div className='menu'>
        <TextField
          label='Пошук'
          className='menu-input'
          value={filterValue}
          onChange={handleFilterChange}
        />
        <Button
          className='menu-input'
          variant='contained'
          color='inherit'
          onClick={() => createUser()}
        >
          Додати користувача
        </Button>
      </div>
      <DataTable tableData={filteredUsers} tableColumns={columns} />
      <UserForm
        open={open}
        update={update}
        user={user}
        setClose={handleClose}
      />
    </div>
  );
};

export { UsersPage };
