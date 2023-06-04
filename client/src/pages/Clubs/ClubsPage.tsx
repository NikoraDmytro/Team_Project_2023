import React, { useEffect, useState } from 'react';
import EditIcon from '@mui/icons-material/Edit';
import DeleteIcon from '@mui/icons-material/Delete';
import { TableColumns } from '../../types/DataTableTypes';
import { DataTable } from '../../components/DataTable';
import SelectForFilter from '../../components/SelectForFilter/SelectForFilter';
import { Button, TextField } from '@mui/material';
import regionalCenters from '../../const/cities';
import './ClubsPage.scss';
import { ClubForm } from '../../components/ClubForm';
import { ClubService } from '../../services';
import { Club } from '../../models/Club';
import { observer } from 'mobx-react-lite';
import { useRootStoreContext } from '../../store';

type ColumnsType = Club & { controls: string };

const ClubsPage = observer(() => {
  const {
    clubsStore: { clubs, fetchClubs },
  } = useRootStoreContext();

  const [filteredClubs, setFilteredClubs] = useState<Club[]>([]);
  const [open, setOpen] = useState(false);
  const [update, setUpdate] = useState(false);
  const [club, setClub] = useState<Club>();

  var filterValue = '';

  const handleClose = () => setOpen(false);

  useEffect(() => {
    fetchClubs();
  }, []);

  const handleChange = (field: string, value: string) => {
    var filtered = clubs.filter(x => x.city === value);
    setFilteredClubs(filtered);
  };

  const editClub = async (item: Club) => {
    setClub(item);
    setUpdate(true);
    setOpen(true);
  };

  const createClub = async () => {
    setUpdate(false);
    setOpen(true);
  };

  const deleteClub = async (id: number) => {
    await ClubService.deleteClub(id);
    fetchClubs();
  };

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
      renderItem: (item: Club) => (
        <div className='control-buttons'>
          <EditIcon onClick={() => editClub(item)} />
          <DeleteIcon
            onClick={() => deleteClub(item.id)}
            className='delete-icon'
          />
        </div>
      ),
    },
  ];
  return (
    <div className='wrapper'>
      <div className='club-menu'>
        <TextField label='Пошук' value={filterValue} />
        <SelectForFilter
          label='Місто'
          items={regionalCenters}
          name='city'
          setFieldValue={handleChange}
        />
        <Button
          variant='contained'
          color='inherit'
          onClick={() => createClub()}
        >
          Додати клуб
        </Button>
      </div>
      <DataTable tableData={filteredClubs} tableColumns={columns} />
      <ClubForm
        open={open}
        club={club}
        update={update}
        setClose={handleClose}
      />
    </div>
  );
});

export { ClubsPage };
