import React, { useState } from 'react';
import { TableColumns } from '../../../../types/DataTableTypes';
import { DataTable } from '../../../../components/DataTable';
import PersonRemoveIcon from '@mui/icons-material/PersonRemove';
import MonitorWeightIcon from '@mui/icons-material/MonitorWeight';
import { Button, TextField } from '@mui/material';
import SelectForFilter from '../../../../components/SelectForFilter/SelectForFilter';
import divisions from '../../../../const/divisions';
import { RegisterSportsmen } from '../../../../components/RegisterSportsmen';
import { WeightnedForm } from '../../../../components/WeightnedForm';

type Competitor = (typeof test)[0];
type ColumnsType = Competitor & { controls: string };

const Competitors = () => {
  const [competitors, setCompetitor] = useState(test);
  const [open, setOpen] = useState(false);
  const [openWeight, setOpenWeight] = useState(false);
  const handleClose = () => setOpen(false);
  const handlleWeightnedForm = () => setOpenWeight(false);

  const columns: TableColumns<Competitor, ColumnsType>[] = [
    {
      name: 'photo',
      label: 'Фото',
    },
    {
      name: 'name',
      label: 'Назва',
      sortable: true,
    },
    {
      name: 'sex',
      label: 'Стать',
    },
    {
      name: 'birthday',
      label: 'Дата народження',
      sortable: true,
    },
    {
      name: 'belt',
      label: 'Статус',
    },
    {
      name: 'club',
      label: 'Клуб',
    },
    {
      name: 'weight',
      label: 'Вага',
      sortable: true,
    },
    {
      name: 'divisions',
      label: 'Дивізіон',
    },
    {
      name: 'membershipCardNum',
      label: 'Номер членського квитка',
    },
    {
      name: 'payment',
      label: 'Оплата',
    },
    {
      name: 'controls',
      renderItem: () => (
        <div className='control-buttons'>
          <PersonRemoveIcon />
          <MonitorWeightIcon onClick={() => setOpenWeight(true)} />
        </div>
      ),
    },
  ];
  return (
    <div>
      <div className='competitors-menu'>
        <TextField label='Пошук' />
        <SelectForFilter label='Клуб' items={clubsTest} />
        <SelectForFilter label='Дивізіони' items={divisions} />
        <SelectForFilter label='Оплата' items={['Сплачено', 'Не сплачено']} />
        <Button
          variant='contained'
          color='inherit'
          onClick={() => setOpen(true)}
        >
          Зареєструвати
        </Button>
      </div>

      <DataTable tableData={competitors} tableColumns={columns} />
      <RegisterSportsmen open={open} setClose={handleClose} />
      <WeightnedForm open={openWeight} setClose={handlleWeightnedForm} />
    </div>
  );
};

export { Competitors };

const clubsTest = ['Клуб 1', 'Клуб 2', 'Клуб 3'];

const test = [
  {
    id: 1,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    belt: '1 дан',
    club: 'СК "ПРАЙД"',
    weight: '40кг',
    divisions: 'Юніори 14-15 років -45кг IДив',
    membershipCardNum: '123456',
    payment: 'Сплачено',
  },
  {
    id: 2,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    belt: '1 дан',
    club: 'СК "ПРАЙД"',
    weight: '40кг',
    divisions: 'Юніори 14-15 років -45кг IДив',
    membershipCardNum: '123456',
    payment: 'Сплачено',
  },
  {
    id: 3,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    belt: '1 дан',
    club: 'СК "ПРАЙД"',
    weight: '40кг',
    divisions: 'Юніори 14-15 років -45кг IДив',
    membershipCardNum: '123456',
    payment: 'Не сплачено',
  },
  {
    id: 4,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    belt: '1 дан',
    club: 'СК "ПРАЙД"',
    weight: '40кг',
    divisions: 'Юніори 14-15 років -45кг IДив',
    membershipCardNum: '123456',
    payment: 'Сплачено',
  },
  {
    id: 5,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    belt: '1 дан',
    club: 'СК "ПРАЙД"',
    weight: '40кг',
    divisions: 'Юніори 14-15 років -45кг IДив',
    membershipCardNum: '123456',
    payment: 'Сплачено',
  },
  {
    id: 6,
    photo: '',
    name: 'Іванов Іван Іванович',
    sex: 'ч',
    birthday: '2005-02-06',
    belt: '1 дан',
    club: 'СК "ПРАЙД"',
    weight: '40кг',
    divisions: 'Юніори 14-15 років -45кг IДив',
    membershipCardNum: '123456',
    payment: 'Сплачено',
  },
];
