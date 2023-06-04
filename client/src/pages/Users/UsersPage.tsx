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
import { useRootStoreContext } from '../../store';
import { observer } from 'mobx-react-lite';

type ColumnsType = User & { controls: string };

const UsersPage = observer(() => {
  const {
    usersStore: { filteredUsers, fetchUsers, setSearch, search },
  } = useRootStoreContext();

  const [open, setOpen] = useState(false);
  const [update, setUpdate] = useState(false);
  const [user, setUser] = useState<User>();

  const handleClose = () => setOpen(false);

  const deleteUser = async (id: number) => {
    await UserService.deleteUser(id);
    fetchUsers();
  };

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
          value={search}
          onChange={e => setSearch(e.target.value)}
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
});

export { UsersPage };
