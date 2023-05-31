import React, { useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import { Button, TextField } from '@mui/material';
import regionalCenters from '../../const/cities';
import './ClubsPage.scss';
import { ClubForm } from '../../components/ClubForm';

type Club = (typeof test)[0];
type ColumnsType = Club & { controls: string };

const ClubsPage = () => {
  const [clubs, setClubs] = useState(test);
  const [open, setOpen] = useState(false);

  const handleClose = () => setOpen(false);

  const columns: TableColumns<Club, ColumnsType>[] = [
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'city',
      label: 'Місто',
    },
    {
      name: 'address',
      label: 'Адреса',
    },
    {
      name: 'controls',
      renderItem: () => (
        <div className='control-buttons'>
          <EditIcon onClick={() => setOpen(true)} />
          <DeleteIcon className='delete-icon' />
        </div>
      ),
    },
  ];
  return (
    <div className='wrapper'>
      <div className='club-menu'>
        <TextField label='Пошук' />
        <SelectForFilter label='Місто' items={regionalCenters} />
        <Button
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
        >
          Додати змагання
        </Button>
      </div>
      <DataTable tableData={clubs} tableColumns={columns} />
      <ClubForm open={open} setClose={handleClose} />
    </div>
  );
};

export { ClubsPage };

const test = [
  {
    id: 1,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 2,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 3,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 4,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 5,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 6,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 7,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 8,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
  {
    id: 9,
    name: 'СК "ПРАЙД"',
    city: 'Харків',
    address: 'вул. Героїв Праці, 4, оф. 553',
  },
];
