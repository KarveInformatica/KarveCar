class ResultObject(object):
    """
         Constructor:
         @param dtoVariableName name of the dto variable to be generated
         @param entityTypeName  entity of the domain to be MapperField
         @param dtoTypeName     dto type to be used for mapping
         @param entityObject    entity object value to be checked for null, related to the entity. i.e. PROVEE1.NUM_PROVEE
     """

    def __init__(self, dtoVariableName, entityTypeName, dtoTypeName, entityObject):
        self.__auxDto = dtoVariableName
        self.__entityAux = entityTypeName
        self.__entityFieldType = dtoTypeName
        self.__entityField = entityObject

    """ data transfer object variable name for the helper """

    @property
    def auxdto(self):
        return self.__auxDto

    @auxdto.setter
    def auxdto(self, x):
        self.__auxDto = x

    """ entity type name for the helper """

    @property
    def entityaux(self):
        return self.__entityAux

    @entityaux.setter
    def entityaux(self, x):
        self.__entityAux = x

    """ dto type name for the helper """

    @property
    def entityfieldtype(self):
        return self.__entityFieldType

    @entityfieldtype.setter
    def entityfieldtype(self, x):
        self.__entityFieldType = x

    @property
    def entityfield(self):
        return self.__entityField

    @entityfield.setter
    def entityfield(self, x):
        self.__entityField = x


class MetaAssist(object):
    """"
    MetaAssist is  class for defining and generating the tags in the assist.
    """
    def __init__(self, tag, dtoname, dtotype):
        self.__tag = tag
        self.__name = dtoname
        self.__dtotype = dtotype
    @property
    def tag(self):
        return self.__tag
    @tag.setter
    def tag(self, x):
        self.__tag = x
    @property
    def dto_name(self):
        return self.__name
    @dto_name.setter
    def dto_name(self, x):
        self.__name= x
    @property
    def dto_type(self):
        return self.__dtotype
    @dto_type.setter
    def dto_type(self, x):
        self.__dtotype= x

class MetaSummaryDto(object):

    def __init__(self, name, type, desc, visualname, namelower):
        self.__field_type = type
        self.__desc = desc
        self.__visualname = visualname
        self.__namelower = namelower
        self.__field_name = name
    @property
    def field_name(self):
        return self.__field_name
    @field_name.setter
    def field_name(self, x):
        self.__field_name = x[0].upper() + x[1:]
    @property
    def field_type(self):
        return self.__type
    @field_type.setter
    def field_type(self, x):
        self.__type = x
    @property
    def field_desc(self):
        return self.__desc
    @field_desc.setter
    def field_desc(self, x):
        self.__desc= x
    @property
    def field_visualname(self):
        return self.__visualname
    @field_visualname.setter
    def field_visualname(self, x):
        self.__visualname= x
    @property
    def field_namelower(self):
        return self.__namelower
    @field_namelower.setter
    def field_namelower(self, x):
        self.__namelower=x
    
class MetaCol(object):
    """
    MetaDto is a class for defining and generating the data transfer object inside the selection wrapper
    """
    def __init__(self,name, localizedname, coldesc, map):
        self.__name = name
        self.__localizedname = localizedname
        self.__coldesc = coldesc
        self.__map = map
    @property
    def name(self):
        return self.__name
    @name.setter
    def name(self,x):
        self.__name = x
    @property
    def map(self):
        return self.__map
    @map.setter
    def map(self,x):
        self.__map = x
    @property
    def localizedname(self):
        return self.__localizedname
    @localizedname.setter
    def localizedname(self,x):
        self.__localizedname=x
    @property
    def coldesc(self):
        return self.__coldesc
    @coldesc.setter
    def coldesc(self,x):
        self.__coldesc=x


class MetaDto(object):
    """
    MetaDto is a class for defining and generating the data transfer object inside the selection wrppaer
    """
    def __init__(self, type, name):
        self.__type = type
        self.__name = name
    @property
    def type(self):
        return self.__type
    @type.setter
    def type(self, x):
        self.__type = x
    @property
    def name(self):
        return self.__name
    @name.setter
    def name(self, x):
        self.__name= x
class TypeMetaObject(object):
    """
    TypeMetaObject is a class for defining and generating the data transfer object for the summary
    """
    def __init__(self):
        self.__fieldType = None
        self.__fieldName = None
        self.__fieldVisualName = None
        self.__fieldDescription = None
    @property
    def field_type(self):
        return self.__fieldType
    @field_type.setter
    def field_type(self, x):
        self.__fieldType = x
    @property
    def field_name(self):
        return self.__fieldName
    @field_name.setter
    def field_name(self, x):
        self.__fieldnName = x
    @property
    def field_visualname(self):
        return self.__fieldVisualName
    @field_visualname.setter
    def field_visualname(self, x):
        self.__fieldVisualName = x
    @property
    def field_descr(self):
        return self.__fieldDescription
    @field_descr.setter
    def field_descr(self, x):
        self.__fieldDescription = x







