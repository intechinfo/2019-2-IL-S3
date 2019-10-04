using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI.PrimarySchool
{
    public class School
    {
        readonly string _name;
        readonly Dictionary<string, Classroom> _classrooms;
        readonly Dictionary<string, Teacher> _teachers;

        public School( string name )
        {
            if( string.IsNullOrWhiteSpace( name ) ) throw new ArgumentException( "The name must be not null nor whitespace.", nameof( name ) );
            _name = name;
            _classrooms = new Dictionary<string, Classroom>();
            _teachers = new Dictionary<string, Teacher>();
        }

        public string Name { get { return _name; } }

        public Teacher AddTeacher( string name )
        {
            if( string.IsNullOrWhiteSpace( name ) ) throw new ArgumentException( "The name must be not null nor whitespace.", nameof( name ) );
            if( _teachers.ContainsKey( name ) ) throw new ArgumentException( "A teacher with this name already exists.", nameof( name ) );

            Teacher teacher = new Teacher( this, name );
            _teachers.Add( name, teacher );
            return teacher;
        }
        
        public Teacher FindTeacher( string name )
        {
            throw new NotImplementedException();
        }

        public Classroom AddClassRoom( string name )
        {
            if( string.IsNullOrWhiteSpace( name ) ) throw new ArgumentException( "The name must be not null nor whitespace.", nameof( name ) );
            if( _classrooms.ContainsKey( name ) ) throw new ArgumentException( "A classroom with this name already exists.", nameof( name ) );

            Classroom classroom = new Classroom( this, name );
            _classrooms.Add( name, classroom );
            return classroom;
        }

        public Classroom FindClassRoom( string name )
        {
            throw new NotImplementedException();
        }

    }
}
