# Gestión de un Hospital

- Tenemos 3 formularios con un DataGridView en cada uno, en el primero mostramos estádisticas generales del hospital, en el segundo información de los pacientes y en el tercero los ingresos y causas de cada paciente.
- Podemos añadir, editar o eliminar pacientes y añadirle a este paciente ingresos que también se pueden editar modificar y borrar.

## ⚠️ Validaciones Implementadas

- **Campos obligatorios**: Nombre, Apellido, Edad, Motivo, Especialidad, Habitación
- **Rango de edad**: Entre 0 y 110 años
- **Selección requerida**: Para editar o eliminar registros
- **Confirmación de eliminación**: Diálogo de confirmación antes de borrar

## 👥 Datos de Ejemplo

La aplicación incluye 4 pacientes de ejemplo con ingresos precargados:
- Carlos Fernández (45 años) - Neumonía (hospitalizado)
- Sofía Martínez (32 años) - Embarazo de alto riesgo (hospitalizada)
- Miguel Torres (67 años) - Post-infarto (dado de alta)
- Laura González (28 años) - Apendicitis (hospitalizada)

## 🐛 Solución de Problemas

**Error al eliminar el último registro**:
- El sistema limpia automáticamente los controles cuando no hay registros evitando crasheos de índice del dataGridView

**DataGridView no se actualiza**:
- El método `RefrescarGrid()` establece `DataSource = null` antes de asignar nuevos datos

**Índice fuera de rango**:
- Los eventos de selección incluyen validación de `CurrentRow != null`

## 📝 Notas de Desarrollo

- Los IDs se generan automáticamente mediante un contador estático
- La fecha de alta `null` indica que el paciente está hospitalizado
- Los datos se pierden al cerrar la aplicación (no hay persistencia)


## 👨‍💻 Autor

Desarrollado por Caín Martínez como proyecto educativo de Windows Forms con C#.

---

**Versión**: 1.0  
**Fecha**: 2025  
**Framework**: .NET Framework 4.8
